# PVSS DUO PRO — Operator Manual
**Version 6.2.1 · ISPTEL · 2022–2026**

---

## Table of Contents
1. [System Overview](#1-system-overview)
2. [Hardware Requirements](#2-hardware-requirements)
3. [Starting the Application](#3-starting-the-application)
4. [Main Screen Layout](#4-main-screen-layout)
5. [Before a Dive — Pre-Job Setup](#5-before-a-dive--pre-job-setup)
6. [Starting and Stopping a Recording](#6-starting-and-stopping-a-recording)
7. [During a Dive](#7-during-a-dive)
8. [Diver 2 Operation](#8-diver-2-operation)
9. [Snapshot Function](#9-snapshot-function)
10. [Depth Chart](#10-depth-chart)
11. [Video Settings](#11-video-settings)
12. [Settings Tab](#12-settings-tab)
13. [GPS Operation](#13-gps-operation)
14. [Recorded Files and Folder Structure](#14-recorded-files-and-folder-structure)
15. [System Monitoring (Info Tab)](#15-system-monitoring-info-tab)
16. [Keyboard Shortcuts Reference](#16-keyboard-shortcuts-reference)
17. [Shutdown Procedure](#17-shutdown-procedure)
18. [Warnings and Alarms](#18-warnings-and-alarms)
19. [Troubleshooting](#19-troubleshooting)

---

## 1. System Overview

PVSS DUO PRO is a dual-channel underwater video surveillance and dive monitoring system.  
It simultaneously records video from two divers, logs depth data in real time, captures snapshots, generates depth charts, and overlays text (OSD) onto the video stream.

**Key capabilities:**
- Dual independent video recording (Diver 1 on drive D:, Diver 2 on drive F:)
- Real-time depth display and dive timer
- Maximum depth tracking per dive
- On-Screen Display (OSD) overlay — company name, diver name, job name, date/time
- GPS position logging
- Telemetry via COM port
- Drive temperature monitoring (SMART / NVMe / ACPI)
- Per-job log file (`log.txt`) recording all events

---

## 2. Hardware Requirements

| Component | Requirement |
|---|---|
| Capture board | Sensoray 2253 (connected via USB) |
| Video inputs | Up to 2 composite/analogue cameras |
| Storage – Diver 1 | Drive **D:\\** (PVSS DUO PRO 1) |
| Storage – Diver 2 | Drive **F:\\** (PVSS DUO PRO 2) |
| Display | 1920 × 1080, primary screen |
| OS | Windows 10/11, 64-bit |
| Privileges | **Run as Administrator** (required for hardware access and temperature reading) |

> **Important:** Always launch the application with **Run as Administrator**. Without elevated privileges, the Sensoray board and temperature monitoring will not initialise correctly.

---

## 3. Starting the Application

1. Power on all cameras and the Sensoray capture board before launching the software.
2. Right-click the **PVSS DUO PRO** shortcut → **Run as administrator**.
3. The **Splash Screen** appears and performs hardware checks:
   - Sensoray board detection
   - Drive space check (D: and F:)
   - Temperature sensor initialisation
4. If all checks pass, the application opens automatically.
5. If a check fails, a warning message is shown in red. An **X (Close)** button appears — click it to exit and investigate the issue before retrying.

---

## 4. Main Screen Layout

The screen is divided into two side-by-side panels:

```
┌─────────────────────────────────────────────────────────────────────────────┐
│  LEFT PANEL – Diver 1                  RIGHT PANEL – Diver 2                │
│  ┌─────────────────┐                  ┌─────────────────────────────────┐   │
│  │ DIVER 1 label   │                  │ DIVER 2 label                   │   │
│  │ Depth (large)   │                  │ Depth (large)                   │   │
│  │ Sensor status   │                  │ Sensor status                   │   │
│  │ Max Depth       │                  │ Max Depth                       │   │
│  │ Dive Timer      │                  │ Dive Timer                      │   │
│  │ REC toggle      │                  │ REC toggle                      │   │
│  │ Camera toggle   │                  │ Camera toggle                   │   │
│  │ Light toggle    │                  │ Light toggle                    │   │
│  │ Video feed      │                  │ Video feed                      │   │
│  │ Tabs: Snapshot  │                  │ Tabs: Snapshot                  │   │
│  │       Chart     │                  │       Chart                     │   │
│  │       Video     │                  │       Video                     │   │
│  │       Info      │                  │       Info                      │   │
│  │       Settings  │                  │       Settings                  │   │
│  └─────────────────┘                  └─────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────────────────┘
```

**Depth display colours:**
- Normal reading — white
- Sensor fault / no data — red or amber warning text below the depth

---

## 5. Before a Dive — Pre-Job Setup

All fields in the Video tab must be set **before** starting a recording. Once recording begins, these fields are locked.

### 5.1 Open the Video Tab
Click the **Video** tab in the bottom-left panel (Diver 1 side).

### 5.2 Enter Job Information

| Field | Description | Max characters |
|---|---|---|
| **Job** | Job name — also used as the folder name for all files | 15 |
| **Company** | Company name shown in the OSD overlay | 15 |
| **Diver Name** | Diver's name shown in the OSD overlay | 15 |

> These fields are shared between Diver 1 and Diver 2.

### 5.3 OSD Overlay Options
- **Show Time** checkbox — displays current time on the video
- **Show Date** checkbox — displays current date on the video
- **Display Timer** — how long OSD text stays on screen: 5 s / 10 s / 15 s / Always On

### 5.4 Video System
Select the correct standard for your cameras:
- **PAL** — 25 fps (Europe, most underwater cameras)
- **NTSC** — 30 fps (Americas, some cameras)

> Selecting the wrong standard will cause a rolling or unstable picture.

### 5.5 Depth Sensor Settings (Settings Tab)
Go to the **Settings** tab:

| Setting | Options | Notes |
|---|---|---|
| Water Type | **Sea Water** / Fresh Water | Affects depth calculation accuracy |
| Sensor Type | **10 BarG** (100 msw) / 25 BarG (250 msw) | Must match the physical sensor fitted |
| Sensor Offset | Numeric (–2.0 to +200.0) | Calibration offset in metres |

> The 25 BarG option is highlighted in red — only use it if a special high-range sensor is fitted.

### 5.6 Telemetry COM Port
1. Select the correct COM port from the **Telemetry COM Port** dropdown.
2. Toggle the switch next to it to **enable** the port.
3. Sensor status will appear below the depth reading once data flows.

---

## 6. Starting and Stopping a Recording

### 6.1 Starting
Toggle the **REC switch** (below the dive timer) to the **ON** position,  
or use the keyboard shortcut: **F3** (Diver 1) / **F4** (Diver 2).

When recording starts:
- The status message changes to **"Recording — F3 STOP"** (Diver 1) or **"Recording — F4 STOP"** (Diver 2)
- The dive timer resets to `00:00:00` and begins counting
- Maximum depth resets to `0.0 m`
- All Job/Company/Diver Name fields become **locked** (greyed out)
- A `Start Recording` entry is written to `log.txt`
- Drive temperature at start is written to `log.txt`

### 6.2 Stopping
Toggle the **REC switch** to **OFF**,  
or use the keyboard shortcut: **F3** (Diver 1) / **F4** (Diver 2) again.

When recording stops:
- The status message changes to **"Stopped — F3 REC"** (Diver 1) or **"Stopped — F4 REC"** (Diver 2)
- Maximum depth achieved is written to `log.txt`
- Drive temperature at end is written to `log.txt`
- Fields are unlocked again (if neither Diver 1 nor Diver 2 is still recording)

> **Note:** Diver 1 and Diver 2 can record independently. Fields only unlock when **both** divers have stopped.

---

## 7. During a Dive

### 7.1 Depth Readings
- **Large number** — current depth in metres (updates in real time)
- **Smaller number** — maximum depth reached during this dive
- **Status text** — sensor connection quality / error message

### 7.2 Dive Timer
Counts `hh:mm:ss` from the moment recording started.

### 7.3 Camera On/Off
Toggle the **Camera** switch to start/stop the live video feed: **F1** (Diver 1) / **F2** (Diver 2).  
The feed can be switched independently from recording.

### 7.4 Lights Control
Toggle the **Light** switch to send an on/off command to the underwater light: **F9** (Diver 1) / **F10** (Diver 2).

**Auto Light Off** checkbox (Video tab): when enabled, the system automatically turns off the underwater light when the diver's depth drops below 1 m while ascending (near-surface detection). Applies to both Diver 1 and Diver 2.

### 7.5 On-Screen Display (OSD) Free Text
Press **F5** (Diver 1) or **F6** (Diver 2) to open the OSD text entry bar on the respective video.  
Type up to 40 characters and press **Enter** to apply.  
Press **F5** / **F6** again to cancel.

---

## 8. Diver 2 Operation

1. Go to the **Settings** tab on the Diver 1 panel.
2. Enable the **Diver 2** toggle switch.
3. The right-hand **Diver 2** panel becomes active.
4. Diver 2 has an identical set of controls operated the same way.
5. Diver 2 video is saved to drive **F:\\PVSS DUO PRO 2\\{JobName}\\Videos2\\**

> Diver 2 can be enabled and disabled mid-session, but not while Diver 2 is recording.

---

## 9. Snapshot Function

Press **F7** (or click the camera icon in the Video tab) to capture a still image from the current video frame.

- The snapshot is saved as a `.jpg` file in `{Drive}:\PVSS DUO PRO x\{JobName}\Snapshots\`
- A thumbnail preview appears in the **Snapshot** tab
- Click the thumbnail to open the full image

---

## 10. Depth Chart

Click the **Chart** tab to view the live depth profile graph.

- The graph plots depth over time for the current recording session
- The chart title displays the diver's name — e.g. **JOHN DEPTH PROFILE**
- A **Save** icon (💾) at the bottom-left saves the chart as a PDF file to `{Drive}:\PVSS DUO PRO x\{JobName}\Charts\`
- The saved PDF uses the diver's name as the chart title

---

## 11. Video Settings

Located in the **Video** tab:

| Control | Description |
|---|---|
| **Brightness** slider | Adjusts video brightness (0–255) |
| **Contrast** slider | Adjusts video contrast (0–255) |
| **Saturation** slider | Adjusts colour saturation (0–255) |
| **Audio Gain** slider | Adjusts microphone/audio input level (0–127) |
| **AGC** checkbox | Automatic Gain Control for audio |
| **Auto Light Off** checkbox | Automatically turns off the light when depth drops below 1 m during ascent — applies to both divers |
| **Open Folder** icon | Opens the job's video folder in Windows Explorer |

---

## 12. Settings Tab

| Setting | Description |
|---|---|
| Diver 2 toggle | Enables/disables the second diver window |
| Telemetry COM Port | Serial port for the depth sensor telemetry |
| COM Port toggle | Enables/disables the telemetry connection |
| GPS COM Port | Serial port for the GPS receiver |
| GPS toggle | Enables/disables GPS |
| GPS Baud Rate | Baud rate for the GPS port |
| Water Type | Sea Water or Fresh Water — affects depth calibration |
| Sensor Type | 10 BarG (100 m) or 25 BarG (250 m) |
| Depth Sensor Offset | Fine-calibration offset in metres |

---

## 13. GPS Operation

1. Connect the GPS receiver to the PC via a USB-to-serial adaptor or direct COM port.
2. In the **Settings** tab, select the **GPS COM Port** and **GPS Baud Rate**.
3. Enable the **GPS toggle**.
4. When a fix is acquired, **Latitude** and **Longitude** values appear in green below the GPS controls.
5. GPS status messages (acquiring / fixed / error) appear in amber.

---

## 14. Recorded Files and Folder Structure

All files are organised automatically under the job name you entered.

**Diver 1 — Drive D:**
```
D:\PVSS DUO PRO 1\
  └── {JobName}\
        ├── Videos1\        ← Video recordings (.avi or .mpg)
        ├── Snapshots1\     ← JPEG snapshots
        ├── Charts1\        ← Depth profile chart images
        └── log.txt         ← Event log for this job
```

**Diver 2 — Drive F:**
```
F:\PVSS DUO PRO 2\
  └── {JobName}\
        ├── Videos2\
        ├── Snapshots2\
        └── Charts2\
```

### log.txt entries

Each job log includes:
- Application start and hardware status
- Start / Stop timestamps for each recording, identified by the diver's name — e.g. `Start Recording - John` / `Stop Recording - John`
- Drive temperature (°C) at start and end — e.g. `Start Dive - Drive Temperature: 36.0 ºC (SSD)`
- Maximum depth reached, identified by diver name — e.g. `Maximum Depth - John was: 24.5 m`
- Dive profile chart save events, identified by diver name — e.g. `Save Dive Profile Chart - John`
- Any errors or warnings

---

## 15. System Monitoring (Info Tab)

Click the **Info** tab to view real-time system status:

| Item | Description |
|---|---|
| Available Disk Space | Free space on the recording drive in GB |
| Available Recording Time | Estimated remaining recording time in hours |
| Internal Temperature | Drive temperature (°C) with source: **(SSD)**, **(NVMe)**, or **(MB)** |
| Board Info | Sensoray board firmware / hardware version |
| DLL Version | Sensoray driver DLL version |

### Temperature colour coding (main display)
| Temperature | Meaning |
|---|---|
| Normal (< 55 °C) | White |
| Warning (> 55 °C) | Amber — monitor the situation |
| Critical (> 65 °C) | Red — stop recording, improve ventilation |

> Temperature re-arms from Warning back to Normal below 48 °C, and from Critical to Warning below 58 °C.

---

## 16. Keyboard Shortcuts Reference

| Key | Diver 1 | Key | Diver 2 |
|---|---|---|---|
| **F1** | Camera On/Off | **F2** | Camera On/Off |
| **F3** | Start / Stop Recording | **F4** | Start / Stop Recording |
| **F5** | Open / Close OSD free text | **F6** | Open / Close OSD free text |
| **F7** | Take Snapshot | **F8** | Take Snapshot |
| **F9** | Lights On/Off | **F10** | Lights On/Off |
| **Enter** | Confirm OSD text (Diver 1 or 2, whichever popup is open) | | |

---

## 17. Shutdown Procedure

1. Ensure **both** divers have stopped recording (status shows "Stopped").
2. Verify all video files have been saved (check the Videos folder).
3. Close the application window (no dedicated close button — use **Alt+F4** or **Task Manager** if needed, but only after stopping recordings).
4. Power off the Sensoray capture board.
5. Power off cameras and lighting equipment.

---

## 18. Warnings and Alarms

### Splash Screen Warnings
If the splash screen shows a warning and the **X** button appears, the system has detected a problem:
- **Sensoray board not found** — check USB connection and power
- **Drive space low** — free space on D: or F: is critically low
- **Temperature critical** — the machine is too hot to safely start a session

Do not proceed with a dive until all warnings are resolved.

### During Operation
- **Sensor Status (red text)** below the depth value — depth sensor has lost signal or is not responding. Check the telemetry cable and COM port settings.
- **Temperature amber/red border** — see Section 15.

---

## 19. Troubleshooting

| Symptom | Likely Cause | Action |
|---|---|---|
| Video feed is black | Camera not powered or wrong COM port | Check camera power and Sensoray connections |
| Depth reads 0.0 m constantly | COM port not enabled or wrong port selected | Go to Settings → enable COM port, select correct port |
| Recording won't start | Drive full or path not accessible | Check available space in Info tab; verify D: drive is present |
| Temperature shows 0.0 °C (SSD) | No SMART / NVMe data available | Ensure running as Administrator; confirm drive supports SMART |
| Temperature shows 0.0 °C (MB) | No ACPI thermal zones exposed by motherboard | Normal on some motherboards (ASUS B660M-A D4) — SSD/NVMe reading is used instead |
| OSD text not visible on video | Display Timer set too short | Set Display Timer to **Always On** in the Video tab |
| Diver 2 panel not visible | Diver 2 not enabled | Go to Settings tab → toggle **Diver 2** on |
| GPS shows no coordinates | Wrong COM port or baud rate | Match GPS COM port and baud rate to receiver specification |
| Application does not start (Sensoray error in splash screen) | Board not detected | Check USB, power cycle the Sensoray board, re-launch as Administrator |

---

*PVSS DUO PRO Ver 6.2.1 — Created Arlindo Silva — Copyright ISPTEL 2012–2026*
