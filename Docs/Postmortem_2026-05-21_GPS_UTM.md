# Post-Mortem Report — GPS UTM Integration Session
**Date:** 21 May 2026  
**Project:** PVSS Duo Pro  
**Reference Source:** PVSS 5.6 (`D:\_Projecto PVSS\_PVSS Project\_PVSS Code\PVSS 5.6`)  
**Commit:** `a16ea80` → pushed to `github/master`  
**Files changed:** 6 | **Lines added:** +432 | **Lines removed:** -121

---

## 1. Objective

Import GPS sentence handling and UTM display logic from the PVSS 5.6 reference project into PVSS Duo Pro, and apply related UI/UX improvements identified during the review.

---

## 2. Work Performed

### 2.1 UTM Coordinate Conversion
| Item | Detail |
|------|--------|
| **Method added** | `LatLonToUtm(double lat, double lon, out string zone, out double northing, out double easting)` |
| **Algorithm** | WGS84 Transverse Mercator (Karney formulation) — semi-major axis 6 378 137 m, flattening 1/298.257223563, scale factor k₀ = 0.9996, false easting E₀ = 500 000 m, false northing 10 000 000 m (S hemisphere) |
| **Output format** | Northing: `N 4316247.25 29N` · Easting: `E 499254.01` |
| **Source file** | `PVSS/ViewModel/MainViewModel.cs` |

### 2.2 NMEA Sentence Parser — Upgraded
| Before | After |
|--------|-------|
| Parsed GPRMC/GPGGA for lat/lon only | Also computes UTM Northing/Easting per valid fix |
| `GPSStatus` set to empty string on fix | Reports fix type (GPS/DGPS) + satellite count from GGA |
| No Northing/Easting cleared on lost fix | Clears all four fields (Lat, Lon, Northing, Easting) when waiting for fix |

### 2.3 New ViewModel Properties
| Property | Type | Persisted | Purpose |
|----------|------|-----------|---------|
| `Northing` | `string` | No | Formatted UTM northing + zone, bound to UI and OSD |
| `Easting` | `string` | No | Formatted UTM easting, bound to UI and OSD |
| `UseNEonOSD` | `bool` | Yes (`GPSOSDUseNE`) | Toggles video OSD between LAT/LON degrees and UTM N/E |

### 2.4 OSD Update — `SetOSDStyled_LAT_LONG()`
- **Before:** Always displayed `Latitude + "  " + Longitude` on the video overlay.
- **After:** When `UseNEonOSD` is `true`, displays stripped Northing (zone suffix removed) + Easting instead. Zone suffix (e.g. `29N`) is stripped from the OSD line to save horizontal space.

### 2.5 Settings Persistence
Three new user-scoped settings added to `Settings.settings` and `Settings.Designer.cs`:

| Setting | Type | Default |
|---------|------|---------|
| `GPSCOMPort` | `string` | `COM3` |
| `GPSBaudRate` | `int` | `4800` |
| `GPSOSDUseNE` | `bool` | `False` |

`GPSCOMPortListSelectedItem` and `GPSBaudRateSelected` setters now save to settings on every change (previously in-memory only).

### 2.6 GPS COM Port Hot-Plug Fix
**Problem:** COM port dropdown only populated once at app startup. GPS USB adapters plugged in after launch never appeared in the list.

**Solution (matching PVSS 5.6 pattern):**
- Added `RefreshCOMPortsList()` to ViewModel — calls `SerialPort.GetPortNames()` and re-sorts the list.
- Added `DropDownOpened="COMPortComboBox_DropDownOpened"` to **both** the main COM port and GPS COM port `ComboBox` elements in `MainWindow.xaml`.
- Added handler `COMPortComboBox_DropDownOpened()` in `MainWindow.xaml.cs`.

> Note: The reference (PVSS 5.6) only wired the main COM port combobox. This project wires both, as the GPS combobox was the primary failure case.

### 2.7 XAML — Design-Time GPS Visibility
All GPS-related controls in the Settings tab (Longitude, Latitude, Northing, Easting, OSD toggle checkbox) use `Visibility="{Binding GPSIsEnabled, ...}"`. Added `d:Visibility="Visible"` to all seven elements so they are visible in the XAML designer without needing GPS enabled. Also added `d:Text` sample values to the Latitude/Longitude TextBlocks.

### 2.8 UI — Time/Date Checkbox Style
The **Time** and **Date** checkboxes in the Video tab were using `Style="{DynamicResource SimpleCheckBox}"`. Replaced with `Background="#FFF4F4F4"` inline attribute to match the appearance of the **Auto Light Off** checkbox.

---

## 3. Files Modified

| File | Change Summary |
|------|---------------|
| `PVSS/ViewModel/MainViewModel.cs` | `LatLonToUtm()`, `RefreshCOMPortsList()`, updated `ParseNmeaSentence()`, new `Northing`/`Easting`/`UseNEonOSD` props, settings persistence on GPS COM/baud setters, updated `SetOSDStyled_LAT_LONG()` |
| `PVSS/MainWindow.xaml` | Northing/Easting TextBlocks, `UseNEonOSD` CheckBox, `d:Visibility="Visible"` on all GPS controls, `DropDownOpened` on both COM port ComboBoxes, Time/Date checkbox style fix |
| `PVSS/MainWindow.xaml.cs` | `COMPortComboBox_DropDownOpened()` handler |
| `PVSS/Properties/Settings.settings` | Added `GPSCOMPort`, `GPSBaudRate`, `GPSOSDUseNE` |
| `PVSS/Properties/Settings.Designer.cs` | Generated properties for the three new settings |
| `Docs/PVSS_DUO_PRO_Operator_Manual.md` | Minor updates (pre-existing edit) |

---

## 4. Testing Notes

- No compile errors or XAML errors at time of commit.
- `LatLonToUtm` is a pure static function with no external dependencies — zero runtime risk.
- `RefreshCOMPortsList()` is guarded by the existing COM port dropdown open interaction, no background thread involved.
- OSD UTM toggle only fires `SetOSD` calls on both streams; same code path as the existing LAT/LON OSD — no new risk.

---

## 5. Known Limitations / Future Work

| Item | Notes |
|------|-------|
| UTM special zones | Norway/Svalbard (zones 31V/32V, 32X–37X) are not handled — standard 6° zones used throughout. Acceptable for the dive survey use case. |
| GPS combobox separation | Both COM port and GPS port share `COMPortsList`. If a future requirement needs separate lists (e.g. filtering by device descriptor), the binding needs splitting. |
| Settings migration | Users upgrading from a build without `GPSCOMPort`/`GPSBaudRate`/`GPSOSDUseNE` will get defaults (`COM3`, `4800`, `False`) on first run — no migration needed, defaults are safe. |

---

*Report generated: 21 May 2026*
