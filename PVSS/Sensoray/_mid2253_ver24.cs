// Copyright Sensoray Company Inc. 2012 (ver 1.2.24 12 JUL 2016)
// Added Crop Funcion by Arlindo 9 Dez 2015
namespace Sensoray
{
    using System;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Text;
    
    sealed class S2253
    {
        public enum MID2253_VIDSYS
        {
            MID2253_VIDSYS_PAL = 1,
            MID2253_VIDSYS_NTSC = 2
        };

        public enum MID2253_STREAMTYPE
        {
            MID2253_STYPE_MPEG4 = 0,
            MID2253_STYPE_H264 = 1,
            MID2253_STYPE_MJPEG = 2,
            MID2253_STYPE_UYVY = 3,
            MID2253_STYPE_Y800 = 4,
            MID2253_STYPE_M4TS = 5, /* MPEG4 in MPEG transport stream */
            MID2253_STYPE_H4TS = 6, /* H264 in MPEG transport stream */

        };

        public enum MID2253_OSDTYPE
        {
            MID2253_OSDTYPE_TEXT = 1,
            MID2253_OSDTYPE_BMP = 2, // future use
            MID2253_OSDTYPE_LONGTEXT = 3, // large text overlay
	        MID2253_OSDTYPE_STYLEDTEXT = 4, // styled text overlay
	        MID2253_OSDTYPE_RECT = 5, // rectangle overlay
        };

        public enum MID2253_AUDIO_INPUT
        {
            MID2253_AUDIO_MIC = 0,
            MID2253_AUDIO_LINE = 1
        };

        public enum MID2253_OUTPUT_MODE
        {
            MID2253_OUTPUT_IDLE = 0,
            MID2253_OUTPUT_PASSTHRU = 1,
            MID2253_OUTPUT_COLORBARS = 2,
            MID2253_OUTPUT_FLASH = 3,
            MID2253_OUTPUT_STREAM = 4
        };

        public enum MID2253_PARAM
        {
            MID2253_PARAM_FIRMWARE = 0
        };

        public enum MID2253_RECMODE
        {
            MID2253_RECMODE_VIDEO = 0,    // only record video (muxed: .MP4 for MPEG4/H264, .AVI for uncompressed)
            MID2253_RECMODE_AV = 1,       // audio plus video (.MP4 for MPEG4/H264, .AVI for uncompressed)
            MID2253_RECMODE_VES = 2       // only record video elementary stream (AVI mux is used for uncompressed)
        };

        public enum MID2253_MP4MODE
        {
            MID2253_MP4MODE_STANDARD = 0,  // same as MID2253_RECMODE_VIDEO.
            MID2253_MP4MODE_STREAMABLE = 1 // streamable fragmented MP4 (May not play on standard players).
        };

        public enum MID2253_AUDENC {
            MID2253_AUDENC_PCM = 0,          // "no" audio encoding.
            MID2253_AUDENC_G711_ULAW = 2,
            MID2253_AUDENC_G711_ALAW = 3
        };

        public enum MID2253_AUDIO_BITRATE
        {
            MID2253_AUDBR_96 = 96,
            MID2253_AUDBR_128 = 128,
            MID2253_AUDBR_192 = 192,
            MID2253_AUDBR_224 = 224,
            MID2253_AUDBR_256 = 256,
        };

        public enum MID2253_GPIO_SIGNAL
        {
            MID2253_GPIO_LOW,
            MID2253_GPIO_HIGH,
            MID2253_GPIO_CHANGE
        };
        public enum MID2253_PREVIEWTYPE
        {
            MID2253_PREVIEWTYPE_DEFAULT = 0, // DLL chooses best available setting. 
            MID2253_PREVIEWTYPE_VMR9 = 1,    // Force use of VMR 9.
            MID2253_PREVIEWTYPE_VMR7 = 2,    // Force use of VMR 7
            MID2253_PREVIEWTYPE_LEGACY = 3,  //  legacy renderer only supported as pop-up window.
            //XP and later versions of Windows support at least VMR7.
        };
        public enum MID2253P_MODE {
        	MID2253P_MODE_UPDATE = 1,
	        MID2253P_MODE_READ = 2,
	        MID2253P_MODE_UPDATE_READ = 3,
        };
        public enum MID2253P_GPIO_DIRECTION {
        	MID2253P_GPIO_DIR_IN = 0,
	        MID2253P_GPIO_DIR_OUT = 1,
        };
        
        public enum MID2253P_XIO_PAUSE_MODE {
	        MID2253P_XIO_PAUSE_MODE_DISABLE = 0,
	        MID2253P_XIO_PAUSE_MODE_RISING_EDGE = 1,
	        MID2253P_XIO_PAUSE_MODE_FALLING_EDGE = 2,
	        MID2253P_XIO_PAUSE_MODE_LEVEL_HIGH = 3,
	        MID2253P_XIO_PAUSE_MODE_LEVEL_LOW = 4,
        };

        // Constants
        public const int MID2253_LEVEL_CONTRAST = 1;
        public const int MID2253_LEVEL_BRIGHTNESS = 2;
        public const int MID2253_LEVEL_SATURATION = 4;
        public const int MID2253_LEVEL_HUE = 8;

        public const int MID2253_OVERLAY_UPDATE_DISPLAY = 1;
        public const int MID2253_OVERLAY_UPDATE_POSITION = 2;
        public const int MID2253_OVERLAY_UPDATE_TRANSPARENT = 4;

        public const int MUX_ITEMDATA_MP4 = 0;
        public const int MUX_ITEMDATA_VES = 1;
        public const int MUX_ITEMDATA_MP4F = 2;
        public struct RECTANGLE
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        };
        public struct NORMALIZEDRECT {
            public float left;
            public float top;
            public float right;
            public float bottom;
        };

        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Unicode)]
        private struct MID2253STATUS_INTERNAL
        {
            public UInt32 iFileSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)] public byte[] szFilePath;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] public String wcFilePath;

            public Boolean bIsRecording;
            public Boolean bIsRunning;
        };
        
        public struct MID2253STATUS
        {
            public UInt32 iFileSize;            
            public String szFilePath;            
            public String wcFilePath;
            public Boolean bIsRecording;
            public Boolean bIsRunning;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MID2253OSD
        {
            public Int32 osdOn ;    //      // toggles osd on or off.
            public Int32 osdChan ;  // osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B
            public Int32 transparent ;  //whether text transparent or not
            public Int32 positionTop ;  //see xoff, yoff below
            public Int32 ddmm ;     // ddmm=1 puts the day before the month
            public Int32 year2 ;    // year display mode (year2 = 1 means 2 digits, year2=0 means 4 digits)
            public Int32 fraction ;  // whether to display fraction of seconds
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=80)]
            public String line;     // ascii string of text (null terminated)
            public Int32 xoffset ;  //x offset: if positionTop=1, relative to top. if positionTop=0, relative to bottom
            public Int32 yoffset ;  //y offset: if positionTop=1, relative to top. if positionTop=0, relative to bottom
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct MID2253_OSD_LONGTEXT
        {
            public Int32 osdOn;       //OSD on if != 0, 1=8x14 font, 2=16x16 font
            public Int32 osdChan;     // osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B, osdChan=2 for output
            public Int32 transparent; //transparent OSD if !=0, 1=100%, 2=50%, 3=25%
            public Int32 positionTop; //see xoff, yoff below
            public Int32 ddmm;     //date format 0=mm-dd 1=dd-mm 2=mmm-dd, 3=dd-mmm- 4=mmm dd, 5=ddmmm, 6=dd.mm.
            public Int32 year2;    // year display mode (year2 = 1 means 2 digits, year2=0 means 4 digits)
            public Int32 fraction; // whether to display fraction of seconds
            public Int32 xoffset; //x offset: if positionTop=1, relative to top. if positionTop=0, relative to bottom
            public Int32 yoffset; //y offset: if positionTop=1, relative to top. if positionTop=0, relative to bottom
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=160)]
            public String line; // ascii string of text (null terminated)
        };

        public struct  MID2253_OSD_STYLEDTEXT
        {
	        public Int32 osdOn;		// OSD on if != 0
	        public Int32 osdChan;	// osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B, osdChan=2 for output
	        public Int32 id;			// region id: 0..7
	        public Int32 xoffset;	// x offset: relative to left
	        public Int32 yoffset;	// y offset: relative to top
	        public String font;     // font name
	        public Int32 size;       // point size of text
	        public Int32 style;		// bit[0]: bold, bit[1]: italic, bit[2]: outline, bit[3]: underline, bit[4]: shadow
	        public Int32 outline;	// outline style: 0=transparent, 1..7=shaded, 8=black
	        public Int32 background; // background style: 0=transparent, 1..7=shaded, 8=black
	        public Int32 color;      // RGB888 color for text (only used for osdChan=2)
	        public String line;     // pointer to UTF8 text (null terminated) (pointer may be NULL, which will update xoffset and yoffset only)
        };

        [StructLayout(LayoutKind.Sequential)]
        struct MID2253_OSD_STYLEDTEXT_internal
        {
            public Int32 osdOn;		// OSD on if != 0
            public Int32 osdChan;	// osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B, osdChan=2 for output
            public Int32 id;			// region id: 0..7
            public Int32 xoffset;	// x offset: relative to left
            public Int32 yoffset;	// y offset: relative to top
            [MarshalAs(UnmanagedType.LPStr)]
            public String font;     // font name
            public Int32 size;       // point size of text
            public Int32 style;		// bit[0]: bold, bit[1]: italic, bit[2]: outline, bit[3]: underline, bit[4]: shadow
            public Int32 outline;	// outline style: 0=transparent, 1..7=shaded, 8=black
            public Int32 background; // background style: 0=transparent, 1..7=shaded, 8=black
            public Int32 color;      // RGB888 color for text (only used for osdChan=2)
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] line;     // pointer to UTF8 text (null terminated) (pointer may be NULL, which will update xoffset and yoffset only)
        };

        public const int MID2253_STYLE_BOLD = 1;
        public const int MID2253_STYLE_ITALIC = 2;
        public const int MID2253_STYLE_OUTLINE = 4;
        public const int MID2253_STYLE_UNDERLINE = 8;
        public const int MID2253_STYLE_SHADOW = 16;

        [StructLayout(LayoutKind.Sequential)]
        public struct  MID2253_OSD_RECT
        {
	        public Int32 osdOn;		// OSD on if != 0
	        public Int32 osdChan;	// osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B, osdChan=2 for output
	        public Int32 id;			// region id: 0..15
	        public Int32 xoffset;	// x offset: relative to left
	        public Int32 yoffset;	// y offset: relative to top
	        public Int32 width;		// width of rectangle
	        public Int32 height;		// height of rectangle
	        public Int32 color;      // RGB888 color for rectangle (only used for osdChan=2)
        };


        [StructLayout(LayoutKind.Sequential)]
        public struct MID2253CLOCK
        {
            public UInt64 sec;
            public UInt32 usec;
        };
        [StructLayout(LayoutKind.Sequential)]
        public struct MID2253_OVL_STRUCT
        {
            public Byte id;
            public Byte transparent;
            public Byte update;
            public Byte reserved;
            public Int32 xOffset;
            public Int32 yOffset;
            public UInt32 length;
        };

        public static GCHandle gch;

        public static Int32 OpenBoard(Int32 idx)
        {
            return S2253_Open(idx);
        }
        public static Int32 CloseBoard(Int32 hdev)
        {
            return S2253_Close(hdev);
        }
        public static Int32 SetBitrate(Int32 bitrate, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetBitrate(bitrate, devid, strmidx);
            return hr;
        }
        public static Int32 SetVidSys(MID2253_VIDSYS vsys, Int32 devid)
        {
            int hr;
            hr = S2253_SetVidSys(vsys, devid);
            return hr;
        }
        public static Int32 GetVidSys(ref MID2253_VIDSYS vsys, Int32 devid)
        {
            int hr;
            hr = S2253_GetVidSys(ref vsys, devid);
            return hr;
        }

        public static Int32 SetStreamType(Int32 strmtype, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetStreamType(strmtype, devid, strmidx);
            return hr;
        }

        public static Int32 GetStreamType(ref Int32 strmtype, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetStreamType(ref strmtype, devid, strmidx);
            return hr;
        }
        
        public static Int32 SetClock(ref MID2253CLOCK clk, Int32 devid)
        {
            int hr;
            hr = S2253_SetClock(ref clk, devid);
            return hr;

        }
        public static Int32 SetRecordMode(MID2253_RECMODE recmode, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetRecordMode(recmode, devid, strmidx);
            return hr;
        }

        public static Int32 GetRecordMode(ref MID2253_RECMODE recmode, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetRecordMode(ref recmode, devid, strmidx);
            return hr;
        }
        public static Int32 SetMp4Mode(MID2253_MP4MODE mode, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetMp4Mode(mode, devid, strmidx);
            return hr;
        }

        public static Int32 GetRecordMode(ref MID2253_MP4MODE mode, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetMp4Mode(ref mode, devid, strmidx);
            return hr;
        }
        public static Int32 SetJpegQ(Int32 q, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetJpegQ(q, devid, strmidx);
            return hr;
        }

        public static Int32 GetRecordMode(ref Int32 q, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetJpegQ(ref q, devid, strmidx);
            return hr;
        }

        public static Int32 GetStatus(out MID2253STATUS status, Int32 devid, Int32 strmidx)
        {
            int hr;
            MID2253STATUS_INTERNAL status_i;           
            hr = S2253_GetStatus(out status_i, devid, strmidx);
            status.bIsRecording = status_i.bIsRecording;
            status.bIsRunning = status_i.bIsRunning;
            status.iFileSize = status_i.iFileSize;
            status.wcFilePath = status_i.wcFilePath;
            status.szFilePath = System.Text.Encoding.ASCII.GetString(status_i.szFilePath);
            return hr;
        }        
        public static Int32 StartRecord([MarshalAs(UnmanagedType.LPWStr)] String filename, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_StartRecord(filename, 0, devid, strmidx);
            return hr;
        }        
        public static Int32 SetLevel(Int32 param, Int32 level, Int32 devid)
        {
            int hr;
            Byte bval;
            bval = (Byte) level;
            hr = S2253_SetLevel(param, bval, devid);
            return hr;
        }
        public static Int32 GetLevel(Int32 param, ref Int32 level, Int32 devid)
        {
            int hr;
            Byte bval = 0;
            hr = S2253_GetLevel(param, ref bval, devid);
            level = bval;
            return hr;
        }
        
        public static Int32 SetAudioGain(Boolean bAGC, Int32 gain, Int32 devid)
        {
            int hr;
            hr = S2253_SetAudioGain(bAGC, gain, devid);
            return hr;
        }

        public static Int32 GetAudioGain(ref Boolean bAGC, ref Int32 gain, Int32 devid)
        {
            int hr;
            hr = S2253_GetAudioGain(ref bAGC, ref gain, devid);
            return hr;
        }


        public static Int32 StartCallback(Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_StartCallback(devid, strmidx);
            return hr;
        }
        public static Int32 RegisterCallback(DataCallback cb, Int32 devid, Int32 strmidx)
        {
            int hr = 0;
            gch = GCHandle.Alloc(cb);
            hr = S2253_RegisterCallback(cb, devid, strmidx);
            return hr;
        }
        public static Int32 StartDecode(String filename, int bUnicode, Int32 devid)
        {
            int hr;
            hr = S2253_StartDecode(filename, bUnicode, devid);
            return hr;
        }         
        public static Int32 SetPreviewType(MID2253_PREVIEWTYPE type, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetPreviewType(type, devid, strmidx);
            return hr;
        }
        public static Int32 StartPreview(Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_StartPreview(devid, strmidx);
            return hr;
        }           

        public static Int32 StopStream(Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_StopStream(devid, strmidx);
            if (gch.IsAllocated)
                gch.Free();
            return hr;
        }               
         
        // overloaded by type, so need to explicitly specify osdtype
        public static Int32 SetOsd(ref MID2253OSD osd, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetOsd(MID2253_OSDTYPE.MID2253_OSDTYPE_TEXT, ref osd, devid, strmidx);
            return hr;
        }
        public static Int32 SetOsd(ref MID2253_OSD_LONGTEXT osd, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetOsd(MID2253_OSDTYPE.MID2253_OSDTYPE_LONGTEXT, ref osd, devid, strmidx);
            return hr;
        }
        public static Int32 SetOsd(ref MID2253_OSD_STYLEDTEXT osd, Int32 devid, Int32 strmidx)
        {
            int hr;
            MID2253_OSD_STYLEDTEXT_internal r;
            r.osdChan = osd.osdChan;
            r.osdOn = osd.osdOn;
            r.id = osd.id;
            r.font = osd.font;
            r.size = osd.size;
            r.style = osd.style;
            r.xoffset = osd.xoffset;
            r.yoffset = osd.yoffset;
            r.outline = osd.outline;
            r.background = osd.background;
            r.color = osd.color;
            r.line = new byte[Encoding.UTF8.GetByteCount(osd.line) + 1];
            Encoding.UTF8.GetBytes(osd.line, 0, osd.line.Length, r.line, 0);
            hr = S2253_SetOsd(MID2253_OSDTYPE.MID2253_OSDTYPE_STYLEDTEXT, ref osd, devid, strmidx);
            return hr;
        }
        public static Int32 SetOsd(ref MID2253_OSD_RECT osd, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetOsd(MID2253_OSDTYPE.MID2253_OSDTYPE_RECT, ref osd, devid, strmidx);
            return hr;
        }

        public static Int32 SetNotify(IntPtr handle, UInt32 mMessage, Int32 devid)
        {
            int hr;
            hr = S2253_SetNotify(handle, mMessage, devid);
            return hr;
        }
        public static Int32 TestDeviceRemoval(Int32 devid)
        {
            int hr;
            hr = S2253_TestDeviceRemoval(devid);
            return hr;
        }
        public static Int32 TestDecodeDone(Int32 devid)
        {
            int hr;
            hr = S2253_TestDecodeDone(devid);
            return hr;
        }        
        public static Int32 RepaintWindow(IntPtr hdc, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_RepaintWindow(hdc, devid, strmidx);
            return hr;
        }
        public static Int32 GetNumDevices(ref Int32 pNumDevices)
        {
            int hr;
            hr = S2253_GetNumDevices(ref pNumDevices);
            return hr;
        }
        public static Int32 GetSerialNumber(ref UInt32 serial_number, Int32 devid)
        {
            int hr;
            hr = S2253_GetSerialNumber(ref serial_number, devid);
            return hr;
        }

        public static Int32 GetParam(MID2253_PARAM type, ref Int32 val, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetParam(type, ref val, devid, strmidx);
            return hr;
        }
        public static Int32 StartAudioPreview(Int32 devid)
        {
            int hr;
            hr = S2253_StartAudioPreview(devid);
            return hr;
        }
        public static Int32 StopAudioPreview(Int32 devid)
        {
            int hr;
            hr = S2253_StopAudioPreview(devid);
            return hr;
        }
        public static Int32 SetStreamWindow(IntPtr hwnd, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetStreamWindow(hwnd, devid, strmidx);
            return hr;
        }
        public static Int32 SetStreamWindowPosition(RECTANGLE rect, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetStreamWindowPosition(rect, devid, strmidx);
            return hr;
        }
        public static Int32 SetInterpolateMode(Int32 val, Int32 devid)
        {
            int hr;
            hr = S2253_SetInterpolateMode(val, devid);
            return hr;
        }

        /// New CROP function Dez 2015 by Arlindo
        public static Int32 SetInputCrop(Int32 left, Int32 top, Int32 width, Int32 height, Int32 devid)
        {
            int hr;
            hr = S2253_SetInputCrop(left, top, width, height, devid);
            return hr;
        }

        public static Int32 GetInterpolateMode(ref Int32 val, Int32 devid)
        {
            int hr;
            hr = S2253_GetInterpolateMode(ref val, devid);
            return hr;
        }

        public static Int32 FlipImage(Boolean bFlipV, Boolean bFlipH, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_FlipImage(bFlipV, bFlipH, devid, strmidx);
            return hr;
        }
        public static Int32 GetGpioInput(ref Int32 value, Int32 devid)
        {
            int hr;
            hr = S2253_GetGpioInput(ref value, devid);
            return hr;
        }
        public static Int32 SetGpioOutput(Int32 value, Int32 devid)
        {
            int hr;
            hr = S2253_SetGpioOutput(value, devid);
            return hr;
        }
        public static Int32 GetGpioOutput(ref Int32 value, Int32 devid)
        {
            int hr;
            hr = S2253_GetGpioOutput(ref value, devid);
            return hr;
        }
        public static Int32 SetAudioEncoding(MID2253_AUDENC aenc, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetAudioEncoding(aenc, devid, strmidx);
            return hr;
        }
        public static Int32 GetAudioEncoding(ref MID2253_AUDENC aenc, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetAudioEncoding(ref aenc, devid, strmidx);
            return hr;
        }
        public static Int32 SetAudioBitrate(MID2253_AUDIO_BITRATE br, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetAudioBitrate(br, devid, strmidx);
            return hr;
        }
        public static Int32 GetAudioBitrate(ref MID2253_AUDIO_BITRATE br, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetAudioBitrate(ref br, devid, strmidx);
            return hr;
        }
        public static Int32 SetImageSize(Int32 w, Int32 h, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetImageSize(w, h, devid, strmidx);
            return hr;
        }
        public static Int32 GetImageSize(ref Int32 w, ref Int32 h, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetImageSize(ref w, ref h, devid, strmidx);
            return hr;
        }
        public static Int32 GetSample(IntPtr data, UInt32 inlen, ref UInt32 outlen, Int32 to, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_GetSample(data, inlen, ref outlen, to, devid, strmidx);
            return hr;
        }
        public static Int32 EnableSnapshot(Int32 bOn, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_EnableSnapshot(bOn, devid, strmidx);
            return hr;
        }
        public static Int32 WaitGpioInput(MID2253_GPIO_SIGNAL signal, Int32 timout, Int32 devid)
        {
            int hr;
            hr = S2253_WaitGpioInput(signal, timout, devid);
            return hr;
        }

        public static Int32 SetAudioInput(MID2253_AUDIO_INPUT input, Int32 devid)
        {
            int hr;
            hr = S2253_SetAudioInput(input, devid);
            return hr;
        }

        public static Int32 SetIDR(Int32 val, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetIDR(val, devid, strmidx);
            return hr;
        }
        public static Int32 LowLatencyPreview(Boolean bON, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_LowLatencyPreview(bON, devid, strmidx);
            return hr;
        }
        public static Int32 StopDecode(Int32 devid)
        {
            int hr;
            hr = S2253_StopDecode(devid);
            return hr;
        }

        public static Int32 SetOverlay(ref MID2253_OVL_STRUCT ovl, IntPtr data, Int32 devid)
        {
            int hr;
            hr = S2253_SetOverlay(ref ovl, data, devid);
            return hr;
        }

        public static Int32 SetOutputMode(MID2253_OUTPUT_MODE mode, Int32 devid)
        {
            int hr;
            hr = S2253_SetOutputMode(mode, devid);
            return hr;
        }
        public static Int32 SetUserData(String data, Int32 len, Int32 interval, Int32 devid, Int32 strmidx)
        {
            int hr;
            hr = S2253_SetUserData(data, len, interval, devid, strmidx);
            return hr;
        }

        public static Int32 GetHVLock(ref Int32 hvlock, Int32 devid)
        {
            int hr;
            hr = S2253_GetHVLock(ref hvlock, devid);
            return hr;
        }

        public static Int32 ReadOnline(Int32 dev, ref Int32 online) 
        {
            int hr;
            hr = S2253P_ReadOnline(dev, ref online);
            return hr;
        }

        public static Int32 ReadVersion2253P(Int32 dev, ref Int32 version) 
        {
            int hr;
            hr = S2253P_ReadVersion(dev, ref version);
            return hr;
        }
        public static Int32 ReadComstat(Int32 devid, ref Int32 comstat) 
        {
            int hr;
            hr = S2253P_ReadComstat(devid, ref comstat);
            return hr;
        }

        public static Int32 SetSuspend(Int32 devid, Int32 suspend) 
        {
            int hr;
            hr = S2253P_SetSuspend(devid, suspend);
            return hr;
        }

        public static Int32 EncoderReset(Int32 devid, Int32 reset) 
        {
            int hr;
            hr = S2253P_EncoderReset(devid, reset);
            return hr;
        }

        public static Int32 EncoderLoad(Int32 devid, Int32 encoderId, Int32 value) 
        {
            int hr;
            hr = S2253P_EncoderLoad(devid, encoderId, value);
            return hr;
        }

        public static Int32 EnableEncoderAsync(Int32 devid, Int32 encoderId, Int32 enable) 
        {
            int hr;
            hr = S2253P_EnableEncoderAsync(devid, encoderId, enable);
            return hr;
        }

        public static Int32 EncoderRead(Int32 devid, Int32 encoderId, MID2253P_MODE mode, ref Int32 value)
        {
            int hr;
            hr = S2253P_EncoderRead(devid, encoderId, mode, ref value);
            return hr;
        }


        public static Int32 GpioConfig(Int32 devid, Int32 gpioId, MID2253P_GPIO_DIRECTION gpio)
        {
            int hr;
            hr = S2253P_GpioConfig(devid, gpioId, gpio);
            return hr;
        }


        public static Int32 GpioWrite(Int32 devid, Int32 gpioId, Int32 value) 
        {
            int hr;
            hr = S2253P_GpioWrite(devid, gpioId, value);
            return hr;
        }


        public static Int32 GpioRead(Int32 devid, Int32 gpioId, ref Int32 value, MID2253P_GPIO_DIRECTION gpio)
        {
            int hr;
            hr = S2253P_GpioRead(devid, gpioId, ref value, gpio);
            return hr;
        }


        public static Int32 EnableXIOAsync(Int32 devid, Int32 xioId, Int32 enable)
        {
            int hr;
            hr = S2253P_EnableXIOAsync(devid, xioId, enable);
            return hr;
        }


        public static Int32 ReadXIO(Int32 devid, Int32 xioId, ref Int32 val, MID2253P_MODE mode)
        {
            int hr;
            hr = S2253P_ReadXIO(devid, xioId, ref val, mode);
            return hr;
        }

        
        public static Int32 PauseConfigXIO(Int32 devid, Int32 streamId, Int32 xioId, MID2253P_XIO_PAUSE_MODE pausemode)
        { 
            int hr;
            hr = S2253P_PauseConfigXIO(devid, streamId, xioId, pausemode);
            return hr;
        }

        
        public static Int32 EnableGPS(Int32 devid, Int32 enable)
        {
            int hr;
            hr = S2253P_EnableGPS(devid, enable);
            return hr;
        }

        
        public static Int32 ReadGPSStatus(Int32 devid, ref Int32 status)
        {
            int hr;
            hr = S2253P_ReadGPSStatus(devid, ref status);
            return hr;
        }
        
        public static Int32 ReadLatitude(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadLatitude(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }
        
        public static Int32 ReadLongitude(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadLongitude(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadAltitude(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadAltitude(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadSpeed(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadSpeed(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadCourse(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadCourse(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        
        public static Int32 ReadUTCTime(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadUTCTime(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        
        public static Int32 ReadUTCDate(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadUTCDate(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadSatellites(Int32 devid, ref Int32 value)
        {
            int hr;
            hr = S2253P_ReadSatellites(devid, ref value);
            return hr;
        }

        public static Int32 ReadLock(Int32 devid, ref Int32 value)
        {
            int hr;
            hr = S2253P_ReadLock(devid, ref value);
            return hr;
        }

        public static Int32 ReadGPS_GGA(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadGPS_GGA(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadGPS_GSA(Int32 devid, ref String value, Int32 size) {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadGPS_GSA(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadGPS_GSV(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadGPS_GSV(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 ReadGPS_RMC(Int32 devid, ref String value, Int32 size)
        {
            int hr;
            byte[] txt = new byte[260];
            GCHandle txtHandle;
            IntPtr txtPtr;
            txtHandle = GCHandle.Alloc(txt, GCHandleType.Pinned);
            txtPtr = (IntPtr)txtHandle.AddrOfPinnedObject();
            hr = S2253P_ReadGPS_RMC(devid, txtPtr, size);
            value = System.Text.Encoding.Default.GetString(txt).Trim();
            value = value.Trim('\0');
            return hr;
        }

        public static Int32 DrawBitmap(IntPtr hdcBMP, ref RECTANGLE src,
                                        ref NORMALIZEDRECT dst, float alpha, int devid, int strmid) {
            int retVal;
            retVal = S2253_DrawBitmap(hdcBMP, ref src, ref dst, alpha, devid, strmid);
            return retVal;
        }
        public static Int32 DrawBitmapColorRef(IntPtr hdcBMP, ref RECTANGLE src,
                                        ref NORMALIZEDRECT dst, float alpha, UInt32 clrSrcKey, int devid, int strmid) {
            int retVal;
            retVal = S2253_DrawBitmapColorRef(hdcBMP, ref src, ref dst, alpha, clrSrcKey, devid, strmid);
            return retVal;
        }

#if _WIN64
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_Open(Int32 brdidx);

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_Close(Int32 brdidx);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetNumDevices(ref Int32 pNumDevices);
    
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetVidSys(MID2253_VIDSYS vidsys, Int32 devid);

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetVidSys(ref MID2253_VIDSYS vidsys, Int32 devid);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetStatus(out MID2253STATUS_INTERNAL pStatus, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetRecordMode(MID2253_RECMODE recmode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetRecordMode(ref MID2253_RECMODE recmode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetMp4Mode(MID2253_MP4MODE mp4mode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetMp4Mode(ref MID2253_MP4MODE mp4mode, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioEncoding(MID2253_AUDENC aenc, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioEncoding(ref MID2253_AUDENC aenc, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioBitrate(MID2253_AUDIO_BITRATE audbr, Int32 devid, Int32 strmidx);
     
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioBitrate(ref MID2253_AUDIO_BITRATE audbr, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartRecord(String filename, Int32 bUnicode, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetLevel(Int32 param, Byte value, Int32 devid);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetLevel(Int32 param, ref Byte value, Int32 devid);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartPreview(Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartAudioPreview(Int32 devid);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StopAudioPreview(Int32 devid);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StopStream(Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetImageSize(Int32 w, Int32 h, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetImageSize(ref Int32 w, ref Int32 h, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetStreamType(Int32 stype, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetStreamType(ref Int32 stype, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253OSD osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_LONGTEXT osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_STYLEDTEXT osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_RECT osd, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetClock(ref MID2253CLOCK clk, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetBitrate(Int32 bitrate, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetBitrate(ref Int32 bitrate, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetJpegQ(Int32 q, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetJpegQ(ref Int32 q, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetInterpolateMode(Int32 val, Int32 devid);
    
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetInterpolateMode(ref Int32 val, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StartSnapshot(Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetSample(IntPtr data, UInt32 inlen, ref UInt32 outlen, Int32 to, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_EnableSnapshot(Int32 bOn, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetSerialNumber(ref UInt32 serial_number, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetStreamWindow(IntPtr hwnd, Int32 devid, Int32 strmidx);
    
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetStreamWindowPosition(RECTANGLE rect, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_RepaintWindow(IntPtr hdc, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetGpioInput(ref Int32 value, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetGpioOutput(Int32 value, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetGpioOutput(ref Int32 value, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_WaitGpioInput(MID2253_GPIO_SIGNAL signal, Int32 timout, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioInput(MID2253_AUDIO_INPUT input, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioGain(Boolean bAGC,  Int32 gain, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioGain(ref Boolean bAGC, ref Int32 gain, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_FlipImage(Boolean bFlipV, Boolean bFlipH, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetIDR(Int32 val, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_LowLatencyPreview(Boolean bON, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StartDecode(String filename, Int32 bUnicode, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StopDecode(Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetNotify(IntPtr hNotifyAPp, UInt32 mNotifyMsg, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_TestDeviceRemoval(Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_TestDecodeDone(Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOverlay(ref MID2253_OVL_STRUCT ovl, IntPtr data, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetOutputMode(MID2253_OUTPUT_MODE mode, Int32 devid);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetParam(MID2253_PARAM type, ref Int32 val, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetUserData(String data, Int32 len, Int32 interval, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartCallback(Int32 devid, Int32 strmidx);
    
   public delegate Int32 DataCallback(IntPtr merged, Int32 size, Int32 board, Int32 strmidx);

   [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_RegisterCallback(DataCallback cb, Int32 devid, Int32 strmidx);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_GetHVLock(ref Int32 hvlock, Int32 devid);
    
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_SetPreviewType(MID2253_PREVIEWTYPE type, Int32 devid, Int32 strmidx);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadOnline(Int32 devid, ref Int32 online);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadVersion(Int32 devid, ref Int32 version);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadComstat(Int32 devid, ref Int32 comstat);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_SetSuspend(Int32 devid, Int32 suspend);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderReset(Int32 devid, Int32 reset);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderLoad(Int32 devid, Int32 encoderId, Int32 value);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableEncoderAsync(Int32 devid, Int32 encoderId, Int32 enable);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderRead(Int32 devid, Int32 encoderId, MID2253P_MODE mode, ref Int32 value);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioConfig(Int32 devid, Int32 gpioId, MID2253P_GPIO_DIRECTION gpio);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioWrite(Int32 devid, Int32 gpioId, Int32 value);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioRead(Int32 devid, Int32 gpioId, ref Int32 value, MID2253P_GPIO_DIRECTION gpio);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableXIOAsync(Int32 devid, Int32 xioId, Int32 enable);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadXIO(Int32 devid, Int32 xioId, ref Int32 val, MID2253P_MODE mode);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_PauseConfigXIO(Int32 devid, Int32 streamId, Int32 xioId, MID2253P_XIO_PAUSE_MODE pausemode);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableGPS(Int32 devid, Int32 enable);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPSStatus(Int32 devid, ref Int32 status);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLatitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLongitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadSpeed(Int32 devid, IntPtr value, Int32 size);
    
    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadAltitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadCourse(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadUTCTime(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadUTCDate(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadSatellites(Int32 devid, ref Int32 value);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLock(Int32 devid, ref Int32 value);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GGA(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GSA(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GSV(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_RMC(Int32 devid, IntPtr value, Int32 size);


    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_DrawBitmap(IntPtr hdcBMP, ref RECTANGLE src, ref NORMALIZEDRECT dst,
                                        float alpha, int devid, int strmidx);

    [DllImport("mid2253_x64.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_DrawBitmapColorRef(IntPtr hdcBMP, ref RECTANGLE src, ref NORMALIZEDRECT dst,
                                                float alpha, UInt32 clrSrcKey, int devid, int strmidx);

    [DllImport("gdi32.dll", EntryPoint = "SelectObject", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);



#else
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_Open(Int32 brdidx);

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_Close(Int32 brdidx);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetNumDevices(ref Int32 pNumDevices);
    
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetVidSys(MID2253_VIDSYS vidsys, Int32 devid);

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetVidSys(ref MID2253_VIDSYS vidsys, Int32 devid);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetStatus(out MID2253STATUS_INTERNAL pStatus, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetRecordMode(MID2253_RECMODE recmode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetRecordMode(ref MID2253_RECMODE recmode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetMp4Mode(MID2253_MP4MODE mp4mode, Int32 devid, Int32 strmidx);
    

        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetMp4Mode(ref MID2253_MP4MODE mp4mode, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioEncoding(MID2253_AUDENC aenc, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioEncoding(ref MID2253_AUDENC aenc, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioBitrate(MID2253_AUDIO_BITRATE audbr, Int32 devid, Int32 strmidx);
     
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioBitrate(ref MID2253_AUDIO_BITRATE audbr, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartRecord(String filename, Int32 bUnicode, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetLevel(Int32 param, Byte value, Int32 devid);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetLevel(Int32 param, ref Byte value, Int32 devid);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartPreview(Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartAudioPreview(Int32 devid);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StopAudioPreview(Int32 devid);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StopStream(Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetImageSize(Int32 w, Int32 h, Int32 devid, Int32 strmidx);
    
        [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetImageSize(ref Int32 w, ref Int32 h, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetStreamType(Int32 stype, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetStreamType(ref Int32 stype, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253OSD osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_LONGTEXT osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_STYLEDTEXT osd, Int32 devid, Int32 strmidx);
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetOsd(MID2253_OSDTYPE osdtype, ref MID2253_OSD_RECT osd, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetClock(ref MID2253CLOCK clk, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetBitrate(Int32 bitrate, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetBitrate(ref Int32 bitrate, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetJpegQ(Int32 q, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetJpegQ(ref Int32 q, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetInterpolateMode(Int32 val, Int32 devid);
    
    //New CROP function Dez2015 by Arlindo
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_SetInputCrop(Int32 left, Int32 top, Int32 width, Int32 height, Int32 devid);

    
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetInterpolateMode(ref Int32 val, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StartSnapshot(Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetSample(IntPtr data, UInt32 inlen, ref UInt32 outlen, Int32 to, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_EnableSnapshot(Int32 bOn, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetSerialNumber(ref UInt32 serial_number, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetStreamWindow(IntPtr hwnd, Int32 devid, Int32 strmidx);
    
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetStreamWindowPosition(RECTANGLE rect, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_RepaintWindow(IntPtr hdc, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetGpioInput(ref Int32 value, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetGpioOutput(Int32 value, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetGpioOutput(ref Int32 value, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_WaitGpioInput(MID2253_GPIO_SIGNAL signal, Int32 timout, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioInput(MID2253_AUDIO_INPUT input, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetAudioGain(Boolean bAGC,  Int32 gain, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetAudioGain(ref Boolean bAGC, ref Int32 gain, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_FlipImage(Boolean bFlipV, Boolean bFlipH, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetIDR(Int32 val, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_LowLatencyPreview(Boolean bON, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StartDecode(String filename, Int32 bUnicode, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_StopDecode(Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetNotify(IntPtr hNotifyAPp, UInt32 mNotifyMsg, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_TestDeviceRemoval(Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_TestDecodeDone(Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
       static extern Int32 S2253_SetOverlay(ref MID2253_OVL_STRUCT ovl, IntPtr data, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetOutputMode(MID2253_OUTPUT_MODE mode, Int32 devid);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_GetParam(MID2253_PARAM type, ref Int32 val, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_SetUserData(String data, Int32 len, Int32 interval, Int32 devid, Int32 strmidx);
    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_StartCallback(Int32 devid, Int32 strmidx);
    
   public delegate Int32 DataCallback(IntPtr merged, Int32 size, Int32 board, Int32 strmidx);

   [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        static extern Int32 S2253_RegisterCallback(DataCallback cb, Int32 devid, Int32 strmidx);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_GetHVLock(ref Int32 hvlock, Int32 devid);
    
    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_SetPreviewType(MID2253_PREVIEWTYPE type, Int32 devid, Int32 strmidx);    

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadOnline(Int32 devid, ref Int32 online);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadVersion(Int32 devid, ref Int32 version);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadComstat(Int32 devid, ref Int32 comstat);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_SetSuspend(Int32 devid, Int32 suspend);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderReset(Int32 devid, Int32 reset);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderLoad(Int32 devid, Int32 encoderId, Int32 value);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableEncoderAsync(Int32 devid, Int32 encoderId, Int32 enable);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EncoderRead(Int32 devid, Int32 encoderId, MID2253P_MODE mode, ref Int32 value);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioConfig(Int32 devid, Int32 gpioId, MID2253P_GPIO_DIRECTION gpio);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioWrite(Int32 devid, Int32 gpioId, Int32 value);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_GpioRead(Int32 devid, Int32 gpioId, ref Int32 value, MID2253P_GPIO_DIRECTION gpio);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableXIOAsync(Int32 devid, Int32 xioId, Int32 enable);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadXIO(Int32 devid, Int32 xioId, ref Int32 val, MID2253P_MODE mode);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_PauseConfigXIO(Int32 devid, Int32 streamId, Int32 xioId, MID2253P_XIO_PAUSE_MODE pausemode);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_EnableGPS(Int32 devid, Int32 enable);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPSStatus(Int32 devid, ref Int32 status);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLatitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLongitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadAltitude(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadSpeed(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadCourse(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadUTCTime(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadUTCDate(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadSatellites(Int32 devid, ref Int32 value);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadLock(Int32 devid, ref Int32 value);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GGA(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GSA(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_GSV(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253P_ReadGPS_RMC(Int32 devid, IntPtr value, Int32 size);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_DrawBitmap(IntPtr hdcBMP, ref RECTANGLE src, ref NORMALIZEDRECT dst,
                                        float alpha, int devid, int strmidx);

    [DllImport("mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    static extern Int32 S2253_DrawBitmapColorRef(IntPtr hdcBMP, ref RECTANGLE src, ref NORMALIZEDRECT dst,
                                        float alpha, UInt32 clrSrcKey, int devid, int strmidx);

    [DllImport("gdi32.dll", EntryPoint = "SelectObject", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);


#endif
        
[StructLayout( LayoutKind.Sequential )]
public struct MID2253_OSD_BMP
{
  public int osdOn;                // OSD on if != 0
  public int osdChan;        // osd channel to update.  osdChan=0 for stream A, osdChan=1 for stream B, osdChan=2 for output, osdChan=3 for both streams
  public int id;                // region id: 0..15
  public int xoffset;        // x offset: relative to left
  public int yoffset;        // y offset: relative to top
  public IntPtr bmp;               // pointer to bitmap image data (as loaded from file)
};




public static Int32 SetOsd( ref MID2253_OSD_BMP osd, Int32 devid, Int32 strmidx )
{
  int hr;
  MID2253_OSD_BMP r;
  r.osdChan = osd.osdChan;
  r.osdOn = osd.osdOn;
  r.id = osd.id;
  r.xoffset = osd.xoffset;
  r.yoffset = osd.yoffset;
  r.bmp = osd.bmp;

  hr = S2253_SetOsd( MID2253_OSDTYPE.MID2253_OSDTYPE_BMP, ref r, devid, strmidx );
  return hr;
}



[DllImport( "mid2253.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true )]
static extern Int32 S2253_SetOsd( MID2253_OSDTYPE osdtype, ref MID2253_OSD_BMP osd, Int32 devid, Int32 strmidx );



    private S2253() { }
    }
}