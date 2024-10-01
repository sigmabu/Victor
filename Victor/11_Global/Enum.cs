#region IO
public enum eX
{
    X00 = 0,
    /// <summary>
    /// 
    /// </summary>
    SYS_MC = 0,
    X01 = 1,
    /// <summary>
    /// 메인 공압 센서
    /// </summary>
    SYS_Pneumatic = 1,
    X02 = 2,
    /// <summary>
    /// Emergency Controller
    /// </summary>
    SYS_EMGController = 2,
    X03 = 3,
    /// <summary>
    /// 장비 전면(왼쪽) Emergency Button
    /// </summary>
    SYS_EMGFront_L = 3,
    X04 = 4,
    /// <summary>
    /// 장비 전면(오른쪽) Emergency Button
    /// </summary>
    SYS_EMGFront_R = 4,
    X05 = 5,
    /// <summary>
    /// 장비 후면(왼쪽) Emergency Button
    /// </summary>
    SYS_EMGRear_L = 5,
    X06 = 6,
    /// <summary>
    /// 장비 후면(오른쪽) Emergency Button
    /// </summary>
    SYS_EMGRear_R = 6,
    X07 = 7,
    X08 = 8,
    /// <summary>
    /// Start Button (장비 전면)
    /// </summary>
    SYS_BtnStart = 8,
    X09 = 9,
    /// <summary>
    /// Stop Button (장비 전면)
    /// </summary>
    SYS_BtnStop = 9,
    X0A = 10,
    /// <summary>
    /// Reset Button (장비 전면)
    /// </summary>
    SYS_BtnReset = 10,
    X0B = 11,
    /// <summary>
    /// Gripper Clamp On-Rear (U 전용)
    /// </summary>
    INR_GripperClampOn_Rear = 11,
    X0C = 12,
    /// <summary>
    /// Gripper Clamp Off-Rear (U 전용)
    /// </summary>
    INR_GripperClampOff_Rear = 12,
    X0D = 13,
    /// <summary>
    /// Carrier Detect Sensor
    /// </summary>
    INR_CarrierDetect = 13,
    X0E = 14,
    /// <summary>
    /// Left Tool Setter
    /// </summary>
    SYS_ToolsetterL = 14,
    X0F = 15,
    /// <summary>
    /// Right Tool Setter
    /// </summary>
    SYS_ToolsetterR = 15,
    X10 = 16,
    /// <summary>
    /// Inrail 자재 감지 Sensor (Loader Pusher가 Inrail로 자재 투입 시 감지하는 센서)
    /// </summary>
    INR_StripInDetect = 16,
    X11 = 17,
    /// <summary>
    /// Inrail 자재 바닥면 감지 Sensor (Inrail에 자재가 안착됐는지 확인하기 위해 바닥면을 감지하는 센서)
    /// </summary>
    INR_StripBtmDetect = 17,
    X12 = 18,
    /// <summary>
    /// Inrail 자재 고정(Forward) Sensor (Inrail에 있는 자재를 고정할 때, 이를 감지하는 센서)
    /// </summary>
    INR_GuideForward = 18,
    X13 = 19,
    /// <summary>
    /// Inrail 자재 고정 해제(Backward) Sensor (Inrail에서 고정한 자재를 고정 해제할 때, 이를 감지하는 센서)
    /// </summary>
    INR_GuideBackward = 19,
    X14 = 20,
    /// <summary>
    /// Inrail Gripper 스트립 감지 Sensor
    /// </summary>
    INR_GripperDetect = 20,
    X15 = 21,
    /// <summary>
    /// Inrail Gripper Clamp on Sensor
    /// </summary>
    INR_GripperClampOn = 21,
    X16 = 22,
    /// <summary>
    /// Inrail Gripper clamp off Sensor
    /// </summary>
    INR_GripperClampOff = 22,
    X17 = 23,
    /// <summary>
    /// Unit #1 Detect  (U 전용)
    /// </summary>
    INR_Unit_1_Detect = 23,
    X18 = 24,
    /// <summary>
    /// Inrail Lift Up Sensor
    /// </summary>
    INR_LiftUp = 24,
    X19 = 25,
    /// <summary>
    /// Inrail Lift Down Sensor
    /// </summary>
    INR_LiftDn = 25,
    X1A = 26,
    //20190611 ghk_onpclean
    /// <summary>
    /// Inrail LoaderPicker Cleaner Left
    /// </summary>
    INR_OnpCleaner_L = 26,
    X1B = 27,
    /// <summary>
    /// Inrail LoaderPicker Cleaner Right
    /// </summary>
    INR_OnpCleaner_R = 27,
    X1C = 28,
    /// <summary>
    /// Unit #2 Detect  (U 전용)
    /// </summary>
    INR_Unit_2_Detect = 28,
    X1D = 29,
    /// <summary>
    /// Unit 캐리어에 안착 시 틀어짐 확인 (Only U)
    /// </summary>
    INR_Unit_Tilt = 29,
    X1E = 30,
    /// <summary>
    /// Inrail 프로브 업
    /// </summary>
    INR_ProbeUp = 30,
    X1F = 31,
    /// <summary>
    /// Inrail 프로브 다운
    /// </summary>
    INR_ProbeDn = 31,
    X20 = 32,
    /// <summary>
    /// Loader Picker 회전각도 0도 Sensor (Table 하고 같은 방향)
    /// </summary>
    ONP_Rotate0 = 32,
    X21 = 33,
    /// <summary>
    /// Loader Picker 회전각도 90도 Sensor (Table 모양에서 90도 회전한 방향)
    /// </summary>
    ONP_Rotate90 = 33,
    X22 = 34,
    /// <summary>
    /// Loader Picker 진공흡입 Sensor (onloader Picker가 자재를 흡착했을 때 감지되는 센서)
    /// </summary>
    ONP_Vacuum = 34,
    X23 = 35,
    /// <summary>
    /// Unit #3 Detect (U 전용)
    /// </summary>
    INR_Unit_3_Detect = 35,
    X24 = 36,
    /// <summary>
    /// Unit #4 Detect (U 전용)
    /// </summary>
    INR_Unit_4_Detect = 36,
    X25 = 37,
    X26 = 38,
    /// <summary>
    /// Loader Picker Loadcell Sensor (Loader Picker 하부에 일정 압력이 가해지면 감지되는 센서) 
    /// </summary>
    ONP_LoadCell = 38,
    X27 = 39,
    X28 = 40,
    /// <summary>
    /// Grind 전면 Door Sensor (장비 전면에 있는 문이 닫힐 때 감지되는 센서)
    /// </summary>
    GRD_DoorFront = 40,
    X29 = 41,
    /// <summary>
    /// Grind 후면 Door Sensor (장비 후면에 있는 문이 닫힐 때 감지되는 센서)
    /// </summary>
    GRD_DoorRear = 41,
    X2A = 42,
    /// <summary>
    /// Grind 전면 Cover (장비가 러닝중일 때 비산방지를 위해 전면에 있는 커버)
    /// </summary>
    GRD_CoverFront = 42,
    X2B = 43,
    /// <summary>
    /// Grind 후면 Cover (장비가 러닝중일 때 비산방지를 위해 후면에 있는 커버)
    /// </summary>
    GRD_CoverRear = 43,
    X2C = 44,
    X2D = 45,
    X2E = 46,
    /// <summary>
    /// Grind 밑면 누수 감지 센서
    /// </summary>
    GRL_Leak = 46, //ksg : 추가
    X2F = 47,
    /// <summary>
    /// Grind 밑면 누수 감지 센서
    /// </summary>
    GRR_Leak = 47, //ksg : 추가
    X30 = 48,
    /// <summary>
    /// Tool Setter Left
    /// </summary>
    Sys_ToolsetterL = 48,
    X31 = 49,
    /// <summary>
    /// Grind Left Table 진공흡입 Sensor (Left Table이 자재를 흡착했을 때 감지되는 센서)
    /// </summary>
    GRDL_TbVaccum = 49,
    X32 = 50,
    /// <summary>
    /// Grind Left Table Flow Sensor (Left Table에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDL_TbFlow = 50,
    X33 = 51,
    /// <summary>
    /// Grind Left Top Cleaner Down Sensor (Left Top Cleaner가 Down일 때 감지되는 센서)
    /// </summary>
    GRDL_TopClnDn = 51,
    X34 = 52,
    X35 = 53,
    /// <summary>
    /// Grind Left Top Cleaner Flow Sensor (Left Top Cleaner에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDL_TopClnFlow = 53,
    X36 = 54,
    X37 = 55,
    X38 = 56,
    X39 = 57,
    X3A = 58,
    X3B = 59,
    /// <summary>
    /// Grind Left Probe Up Sensor (Grind Left 프로브 센서가 Up일 때 감지되는 센서)
    /// </summary>
    GRDL_ProbeAMP = 59,
    X3C = 60,
    /// <summary>
    /// Grind Left Wheel Zig Sensor (Left Spindle에 Wheel Jig가 삽입되있을 때 감지되는 센서)
    /// </summary>
    GRDL_WheelZig = 60,
    X3D = 61,
    /// <summary>
    /// Unit #1 Vacuum Left Table  (U 전용)
    /// </summary>
    GRDL_Unit_1_Vacuum = 61,
    X3E = 62,
    /// <summary>
    /// Grind Left Spindle PCW Sensor (Left Spindle에 PCW가 투입될 때 감지되는 센서)
    /// </summary>
    GRDL_SplPCW = 62,
    X3F = 63,
    /// <summary>
    /// Grind Left Spindle PCW 온도 초과 Sensor (Left Spindle에 투입되는 PCW 온도가 유저가 설정한 기준치를 넘었을 때 감지되는 센서)
    /// </summary>
    GRDL_SplPCWTemp = 63,
    X40 = 64,
    /// <summary>
    /// Grind Left Spindle Water Sensor (Left Spindle에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDL_SplWater = 64,
    X41 = 65,
    /// <summary>
    /// Grind Left Spindle Water 온도 초과 Sensor (Left Spindle에서 나오는 물 온도가 유저가 설정한 기준치를 넘었을 때 감지되는 센서)
    /// </summary>
    GRDL_SplWaterTemp = 65,
    X42 = 66,
    /// <summary>
    /// Grind Left Spindle Bottom Water Sensor (Grind Left Bottom에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDL_SplBtmWater = 66,
    X43 = 67,
    /// <summary>
    /// Unit #2 Vacuum LEft Table (U 전용)
    /// </summary>
    GRDL_Unit_2_Vacuum = 67,
    /// <summary>
    /// Grind Left Spindle Bottom Ait Sensor (Grind Left Bottom에서 Air가 나올 때 감지되는 센서)
    /// </summary>
    GRDL_SplBtmAir = 67,
    X44 = 68,
    X45 = 69,
    X46 = 70,
    /// <summary>
    /// Unit #3 Vacuum Left Table  (U 전용)
    /// </summary>
    GRDL_Unit_3_Vacuum = 70,
    X47 = 71,
    /// <summary>
    /// Unit #4 Vacuum Left Table (U 전용)
    /// </summary>
    GRDL_Unit_4_Vacuum = 71,
    X48 = 72,
    X49 = 73,
    /// <summary>
    /// Grind Right Table 진공흡입 Sensor (Right Table이 자재를 흡착했을 때 감지되는 센서)
    /// </summary>
    GRDR_TbVaccum = 73,
    X4A = 74,
    /// <summary>
    /// Grind Right Table Flow Sensor (Right Table에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDR_TbFlow = 74,
    X4B = 75,
    /// <summary>
    /// Grind Right Top Cleaner Down Sensor (Right Top Cleaner가 다운일 때 감지되는 센서)
    /// </summary>
    GRDR_TopClnDn = 75,
    X4C = 76,
    X4D = 77,
    /// <summary>
    /// Grind Right Top Cleaner Flow Sensor (Right Top Cleaner에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDR_TopClnFlow = 77,
    X4E = 78,
    X4F = 79,
    X50 = 80,
    X51 = 81,
    X52 = 82,
    X53 = 83,
    /// <summary>
    /// Grind Right Probe Up Sensor (Grind Right 프로브 센서가 Up일 때 감지되는 센서)
    /// </summary>
    GRDR_ProbeAMP = 83,
    X54 = 84,
    /// <summary>
    /// Grind Right Wheel Jig 감지 Sensor (Right Spindle에 Wheel Jig가 삽입되있을 때 감지되는 센서)
    /// </summary>
    GRDR_WheelZig = 84,
    X55 = 85,
    X56 = 86,
    /// <summary>
    /// Grind Right Spindle PCW Sensor (Right Spindle에 PCW가 투입될 때 감지되는 센서)
    /// </summary>
    GRDR_SplPCW = 86,
    X57 = 87,
    X58 = 88,
    /// <summary>
    /// Grind Right Spindle Water Sensor (Right Spindle에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDR_SplWater = 88,
    X59 = 89,
    /// <summary>
    /// Unit #1 Vacuum Right Table  (U 전용)
    /// </summary>
    GRDR_Unit_1_Vacuum = 89,
    X5A = 90,
    /// <summary>
    /// Grind Right Spindle Bottom Water Sensor (Right Spindle Bottom에서 물이 나올 때 감지되는 센서)
    /// </summary>
    GRDR_SplBtmWater = 90,
    X5B = 91,
    /// <summary>
    /// Unit #2 Vacuum Right Table  (U 전용)
    /// </summary>
    GRDR_Unit_2_Vacuum = 91,
    /// <summary>
    /// Grind Right Spindle Bottom Air Sensor (Right Spindle Bottom에서 Air가 나올 때 감지되는 센서)
    /// </summary>
    GRDR_SplBtmAir = 91,
    X5C = 92,
    X5D = 93,
    X5E = 94,
    /// <summary>
    /// Unit #3 Vacuum Right Table  (U 전용)
    /// </summary>
    GRDR_Unit_3_Vacuum = 94,
    X5F = 95,
    /// <summary>
    /// Unit #4 Vacuum Right Table  (U 전용)
    /// </summary>
    GRDR_Unit_4_Vacuum = 95,
    X60 = 96,
    /// <summary>
    /// Unloader Picker 회전각도 0도 Sensor (Table과 같은 방향)
    /// </summary>
    OFFP_Rotate0 = 96,
    X61 = 97,
    /// <summary>
    /// Unloader Picker 회전각도 90도 Sensor (Table 모양에서 90도 회전한 방향)
    /// </summary>
    OFFP_Rotate90 = 97,
    X62 = 98,
    /// <summary>
    /// Unloader Picker 진공흡입 Sensor (offloader Picker가 자재를 흡착했을 때 감지되는 센서)
    /// </summary>
    OFFP_Vacuum = 98,
    X63 = 99,
    /// <summary>
    /// Dryer Unit #1 Detect
    /// </summary>
    DRY_Unit1_Detect = 99,
    X64 = 100,
    /// <summary>
    /// Dryer Unit #1 Detect
    /// </summary>
    DRY_Unit2_Detect = 100,
    X65 = 101,
    /// <summary>
    /// Dryer Unit #1 Detect
    /// </summary>
    DRY_Unit3_Detect = 101,
    X66 = 102,
    /// <summary>
    /// Unloader Picker Loadcell Sensor (Unloader Picker 하부에 일정 압력이 가해지면 감지되는 센서)
    /// </summary>
    OFFP_LoadCell = 102,
    X67 = 103,
    /// <summary>
    /// Dryer Unit #1 Detect
    /// </summary>
    DRY_Unit4_Detect = 103,
    X68 = 104,
    /// <summary>
    /// Dry Pusher 과부하 Sensor (Dry Pusher가 자재를 밀 때 일정 압력이 가해지면 감지되는 센서)
    /// </summary>
    DRY_PusherOverload = 104,
    X69 = 105,
    /// <summary>
    /// Dry 자재 감지 Sensor (Dry Pusher가 자재를 Unloader MGZ으로 밀 때 감지하는 센서)
    /// </summary>
    DRY_StripOutDetect = 105,
    X6A = 106,
    /// <summary>
    /// Dry Level Safety Sensor 1 (Dry Zone에 자재 안착 시 자재가 제대로 안착됐는지 확인하는 센서)
    /// </summary>
    DRY_LevelSafety1 = 106,
    X6B = 107,
    /// <summary>
    /// Dry Level Safety Sensor 2 (Dry Zone에 자재 안착 시 자재가 제대로 안착됐는지 확인하는 센서)
    /// </summary>
    DRY_LevelSafety2 = 107,
    X6C = 108,
    /// <summary>
    /// Dry Bottom Standby Position Sensor (Dry Bottom Cleaner 대기 포지션, 수정 필요)
    /// </summary>
    DRY_BtmStandbyPos = 108,
    /// <summary>
    /// Dry cover open sensor (only U)
    /// </summary>
    DRY_CoverOpen = 108,
    X6D = 109,
    /// <summary>
    /// Dry Bottom Target Position Sensor (Dry Bottom Cleaner 타겟 포지션, 수정 필요)
    /// </summary>
    DRY_BtmTargetPos = 109,
    /// <summary>
    /// Dry cover close sensor (only U)
    /// </summary>
    DRY_CoverClose = 109,
    X6E = 110,
    /// <summary>
    /// Dry Bottom 밑면 누수 감지 센서
    /// </summary>
    DRY_Leak = 110,
    X6F = 111,
    /// <summary>
    /// Dry Bottom Cleaner Flow Sensor (Bottom Cleaner에서 물이 나올 때 감지되는 센서)
    /// </summary>
    DRY_ClnBtmFlow = 111,
    X70 = 112,
    /// <summary>
    /// Left Pump Run Sensor (왼쪽 펌프 가동할 때 감지되는 센서)
    /// </summary>
    PUMPL_Run = 112,
    X71 = 113,
    /// <summary>
    /// Left Pump Flow Low Sensor (왼쪽 펌프 수압이 기준치보다 낮을 때 감지되는 센서)
    /// </summary>
    PUMPL_FlowLow = 113,
    X72 = 114,
    /// <summary>
    /// Left Pump 온도 초과 Sensor (왼쪽 펌프 수온이 기준치보다 높을 때 감지되는 센서)
    /// </summary>
    PUMPL_TempHigh = 114,
    X73 = 115,
    /// <summary>
    /// Left Pump 과부하 Sensor (왼쪽 펌프가 과부하 상태일 때 감지되는 센서)
    /// </summary>
    PUMPL_OverLoad = 115,
    X74 = 116,
    X75 = 117,
    X76 = 118,
    /// <summary>
    /// Right Pump Run Sensor (오른쪽 펌프 가동할 때 감지되는 센서)
    /// </summary>
    PUMPR_Run = 118,
    X77 = 119,
    /// <summary>
    /// Right Pump Flow Low Sensor (오른쪽 펌프 수압이 기준치보다 낮을 때 감지되는 센서)
    /// </summary>
    PUMPR_FlowLow = 119,
    X78 = 120,
    /// <summary>
    /// Right Pump 온도 초과 Sensor (오른쪽 펌프 수온이 기준치보다 높을 때 감지되는 센서)
    /// </summary>
    PUMPR_TempHigh = 120,
    X79 = 121,
    /// <summary>
    /// Right Pump 과부하 Sensor (오른쪽 펌프가 과부하 상태일 때 감지되는 센서)
    /// </summary>
    PUMPR_OverLoad = 121,
    X7A = 122,
    X7B = 123,
    X7C = 124, IOZL_Alarm = 124,
    X7D = 125, IOZR_Alarm = 125,
    X7E = 126, IOZF_Alarm = 126,
    X7F = 127,
    X80 = 128, TNK_147C = 128,
    X81 = 129, TNK_2580 = 129,
    X82 = 130, TNK_3695 = 130,
    X83 = 131, TNK_123 = 131,
    X84 = 132, TNK_456 = 132,
    X85 = 133, TNK_789 = 133,
    X86 = 134, TNK_C0S = 134,
    X87 = 135,
    /// <summary>
    /// Left Pump 2 Run Sensor (왼쪽 펌프 가동할 때 감지되는 센서)
    /// </summary>
    ADD_PUMPL_Run = 135,        // 2020.10.22 JSKim
    X88 = 136,
    /// <summary>
    /// Left Pump 2 Flow Low Sensor (왼쪽 펌프 수압이 기준치보다 낮을 때 감지되는 센서)
    /// </summary>
    ADD_PUMPL_FlowLow = 136,    // 2020.10.22 JSKim
    X89 = 137,
    /// <summary>
    /// Left Pump 2 온도 초과 Sensor (왼쪽 펌프 수온이 기준치보다 높을 때 감지되는 센서)
    /// </summary>
    ADD_PUMPL_TempHigh = 137,   // 2020.10.22 JSKim
    X8A = 138,
    /// <summary>
    /// Left Pump 2 과부하 Sensor (왼쪽 펌프가 과부하 상태일 때 감지되는 센서)
    /// </summary>
    ADD_PUMPL_OverLoad = 138,   // 2020.10.22 JSKim
    X8B = 139,
    X8C = 140,
    /// <summary>
    /// Right Pump 2 Run Sensor (오른쪽 펌프 가동할 때 감지되는 센서)
    /// </summary>
    ADD_PUMPR_Run = 140,        // 2020.10.22 JSKim
    X8D = 141,
    /// <summary>
    /// Right Pump 2 Flow Low Sensor (오른쪽 펌프 수압이 기준치보다 낮을 때 감지되는 센서)
    /// </summary>
    ADD_PUMPR_FlowLow = 141,    // 2020.10.22 JSKim
    X8E = 142,
    /// <summary>
    /// Right Pump 2 온도 초과 Sensor (오른쪽 펌프 수온이 기준치보다 높을 때 감지되는 센서)
    /// </summary>
    ADD_PUMPR_TempHigh = 142,   // 2020.10.22 JSKim
    X8F = 143,
    /// <summary>
    /// Right Pump 과부하 Sensor (오른쪽 펌프가 과부하 상태일 때 감지되는 센서)
    /// </summary>
    ADD_PUMPR_OverLoad = 143,   // 2020.10.22 JSKim

    X90 = 144,
    /// <summary>
    /// Loader Belt Run Button (Loader 왼쪽면)
    /// </summary>
    ONL_BtnBeltRun = 144,
    X91 = 145,
    X92 = 146,
    /// <summary>
    /// Loader 전면 Emergency Button
    /// </summary>
    ONL_EMGFront = 146,
    X93 = 147,
    /// <summary>
    /// Loader 후면 Emergency Button
    /// </summary>
    ONL_EMGRear = 147,
    X94 = 148,
    /// <summary>
    /// Loader 전면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    ONL_DoorFront = 148,
    X95 = 149,
    /// <summary>
    /// Loader 왼쪽면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    ONL_DoorLeft = 149,
    X96 = 150,
    /// <summary>
    /// Loader 후면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    ONL_DoorRear = 150,
    X97 = 151,
    /// <summary>
    /// Loader Light Curtain (Loader 왼쪽면에 있는 Area Sensor)
    /// </summary>
    ONL_LightCurtain = 151,
    X98 = 152,
    X99 = 153,
    X9A = 154,
    X9B = 155,
    X9C = 156,
    /// <summary>
    /// Loader Top Conveyor MGZ 감지 Sensor 
    /// </summary>
    ONL_TopMGZDetect = 156,
    X9D = 157,
    /// <summary>
    /// Loader Top Conveyor MGZ Full 감지 Sensor (이 Sensor가 감지되면 Top Conveyor에 MGZ이 다 찬 상태로 인식)
    /// </summary>
    ONL_TopMGZDetectFull = 157,
    X9E = 158,
    X9F = 159,
    XA0 = 160,
    /// <summary>
    /// Loader Bottom Conveyor MGZ 감지 Sensor
    /// </summary>
    ONL_BtmMGZDetect = 160,
    XA1 = 161,
    XA2 = 162,
    XA3 = 163,
    XA4 = 164,
    /// <summary>
    /// Loader Pusher 과부하 Sensor (Loader Pusher가 자재를 밀 때 일정 압력이 가해지면 감지되는 센서)
    /// </summary>
    ONL_PusherOverLoad = 164,
    XA5 = 165,
    /// <summary>
    /// Loader Pusher 전진 Sensor (Loader Pusher가 전진했을 때 감지되는 센서)
    /// </summary>
    ONL_PusherForward = 165,
    XA6 = 166,
    /// <summary>
    /// Loader Pusher 후진 Sensor (Loader Pusher가 후진했을 때 감지되는 센서)
    /// </summary>
    ONL_PusherBackward = 166,
    XA7 = 167,
    XA8 = 168,
    /// <summary>
    /// Loader Clamp MGZ Detect Sensor 1 
    /// </summary>
    ONL_ClampMGZDetect1 = 168,
    XA9 = 169,
    /// <summary>
    /// Loader Clamp MGZ Detect Sensor 2
    /// </summary>
    ONL_ClampMGZDetect2 = 169,
    XAA = 170,
    /// <summary>
    /// Loader Clamp On Sensor (Loader Clamp가 Down일 때 감지되는 센서)
    /// </summary>
    ONL_ClampOn = 170,
    XAB = 171,
    /// <summary>
    /// Loader Clamp Off Sensor (Loader Clamp가 Up일 때 감지되는 센서)
    /// </summary>
    ONL_ClampOff = 171,
    XAC = 172,
    XAD = 173,
    XAE = 174,
    XAF = 175,
    XB0 = 176,
    /// <summary>
    /// Unloader Top Belt Run Button (Offloder 오른쪽면)
    /// </summary>
    OFFL_BtnBeltTopRun = 176,
    XB1 = 177,
    /// <summary>
    /// Unloader Bottom Belt Run Button (Offloder 오른쪽면)
    /// </summary>
    OFFL_BtnBeltBtmRun = 177,
    XB2 = 178,
    /// <summary>
    /// Unloader 전면 Emergency Button
    /// </summary>
    OFFL_EMGFront = 178,
    XB3 = 179,
    /// <summary>
    /// Unloader 후면 Emrgency Button
    /// </summary>
    OFFL_EMGRear = 179,
    XB4 = 180,
    /// <summary>
    /// Unloader 전면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    OFFL_DoorFront = 180,
    XB5 = 181,
    /// <summary>
    /// Offlaoder 오른쪽면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    OFFL_DoorRight = 181,
    XB6 = 182,
    /// <summary>
    /// Unloader 후면 Door Sensor (문이 닫힐 때 감지되는 센서)
    /// </summary>
    OFFL_DoorRear = 182,
    XB7 = 183,
    /// <summary>
    /// Unloader Light Curtain (Unloader 오른쪽면에 있는 Area Sensor)
    /// </summary>
    OFFL_LightCurtain = 183,
    XB8 = 184,
    /// <summary>
    /// Unloader Top Conveyor MGZ 감지 Sensor
    /// </summary>
    OFFL_TopMGZDetect = 184,
    XB9 = 185,
    /// <summary>
    /// Unloader Top Conveyor MGZ Full 감지 Sensor (이 Sensor가 감지되면 Top Conveyor에 MGZ이 다 찬 상태로 인식)
    /// </summary>
    OFFL_TopMGZDetectFull = 185,
    XBA = 186,
    XBB = 187,
    /// <summary>
    /// Unloader Middle Conveyor MGZ 감지 Sensor
    /// </summary>
    OFFL_MidMGZDetect = 187,
    // 201116 jym START : IO 추가
    /// <summary>
    /// QC 전면 도어 감지 센서
    /// </summary>
    OFL_QcFrontDoor = 188, XBC = 188,
    /// <summary>
    /// QC 후면 도어 감지 센서
    /// </summary>
    OFL_QcRearDoor = 189, XBD = 189,
    // 201116 jym END
    XBE = 190,
    /// <summary>
    /// Unloader Bottom Conveyor MGZ 감지 Sensor
    /// </summary>
    OFFL_BtmMGZDetect = 190,
    XBF = 191,
    /// <summary>
    /// Unloader Bottom Conveyor MGZ Full 감지 Sensor (이 Sensor가 감지되면 Bottom Conveyor에 MGZ이 다 찬 상태로 인식)
    /// </summary>
    OFFL_BtmMGZDetectFull = 191,
    XC0 = 192,
    /// <summary>
    /// Unloader Top Clamp MGZ 감지 Sensor 1
    /// </summary>
    OFFL_TopClampMGZDetect1 = 192,
    XC1 = 193,
    /// <summary>
    /// Unloader Top Clamp MGZ 감지 Sensor 2
    /// </summary>
    OFFL_TopClampMGZDetect2 = 193,
    XC2 = 194,
    /// <summary>
    /// Unloader Top MGZ Up Sensor (Unloader Top MGZ이 Up 상태일 때 감지되는 센서)
    /// </summary>
    OFFL_TopMGZUp = 194,
    XC3 = 195,
    /// <summary>
    /// Unloader TOp MGZ Down Sensor (Unloader Top MGZ이 Down 상태일 때 감지되는 센서)
    /// </summary>
    OFFL_TopMGZDn = 195,
    XC4 = 196,
    /// <summary>
    /// Unloader Top Clamp On Sensor (Unloader Top Clamp가 Down일 때 감지되는 Sensor)
    /// </summary>
    OFFL_TopClampOn = 196,
    XC5 = 197,
    /// <summary>
    /// Unloader Top Clamp Off Sensor (Unloader Top Clamp가 Up일 때 감지되는 Sensor)
    /// </summary>
    OFFL_TopClampOff = 197,
    XC6 = 198,
    XC7 = 199,
    XC8 = 200,
    /// <summary>
    /// Unloader Bottom Clamp MGZ 감지 Sensor 1
    /// </summary>
    OFFL_BtmClampMGZDetect1 = 200,
    XC9 = 201,
    /// <summary>
    /// Unloader Bottom Clamp MGZ 감지 Sensor 2
    /// </summary>
    OFFL_BtmClampMGZDetect2 = 201,
    XCA = 202,
    /// <summary>
    /// Unloader Bottom MGZ Up Sensor (Unloader Bottom MGZ이 Up일 때 감지되는 센서)
    /// </summary>
    OFFL_BtmMGZUp = 202,
    XCB = 203,
    /// <summary>
    /// Unloader Bottom MGz Down Sensor (Offloder Bottom MGZ이 Down일 때 감지되는 센서)
    /// </summary>
    OFFL_BtmMGZDn = 203,
    XCC = 204,
    /// <summary>
    /// Unloader Bottom Clamp On Sensor (Unloader Bottom Clamp가 Down일 때 감지되는 센서)
    /// </summary>
    OFFL_BtmClampOn = 204,
    XCD = 205,
    /// <summary>
    /// Offlaoder Bottom Clamp Off Sensor (Unloader Bottom Clamp가 Up일 때 감지되는 센서)
    /// </summary>
    OFFL_BtmClampOff = 205,
    XCE = 206,
    XCF = 207
}

public enum eY
{
    Y00 = 0, SYS_MC = 0,
    Y02 = 1,
    Y01 = 2,
    /// <summary>
    /// Tower Lamp Red (장비 상단)
    /// </summary>
    SYS_TwlRed = 2,
    Y03 = 3,
    /// <summary>
    /// Tower Lamp Yellow (장비 상단)
    /// </summary>
    SYS_TwlYellow = 3,
    Y04 = 4,
    /// <summary>
    /// Tower Lamp Green (장비 상단)
    /// </summary>
    SYS_TwlGreen = 4,
    Y05 = 5,
    /// <summary>
    /// Buzzer K1
    /// </summary>
    SYS_BuzzK1 = 5,
    Y06 = 6,
    /// <summary>
    /// Buzzer K2
    /// </summary>
    SYS_BuzzK2 = 6,
    Y07 = 7,
    /// <summary>
    /// Buzzer K3
    /// </summary>
    SYS_BuzzK3 = 7,
    Y08 = 8,
    /// <summary>
    /// Start Button Lamp(Green, 장비 전면)
    /// </summary>
    SYS_BtnStart = 8,
    Y09 = 9,
    /// <summary>
    /// Stop Button Lamp(Red, 장비 전면)
    /// </summary>
    SYS_BtnStop = 9,
    Y0A = 10,
    /// <summary>
    /// Reset Buttom Lamp(Blue, 장비 전면)
    /// </summary>
    SYS_BtnReset = 10,
    Y0B = 11,
    Y0C = 12,
    /// <summary>
    /// 장비 내부 등
    /// </summary>
    SYS_RoomLamp = 12,
    Y0D = 13,
    /// <summary>
    /// Grind Z축 MC 파워
    /// </summary>
    SYS_ZaxisMC = 13,
    Y0E = 14,
    Y0F = 15,
    Y10 = 16,
    Y11 = 17,
    Y12 = 18,
    /// <summary>
    /// Inrail Guide Align Cylinder (자재 고정 실린더, forward/backward)
    /// </summary>
    INR_GuideForward = 18,
    Y13 = 19,
    Y14 = 20,
    Y15 = 21,
    /// <summary>
    /// Inrail Gripper Cylinder (up/dowm)
    /// </summary>
    INR_GripperClampOn = 21,
    Y16 = 22,
    Y17 = 23,
    Y18 = 24,
    /// <summary>
    /// Inrail Lift Cylinder (up/down)
    /// </summary>
    INR_LiftUp = 24,
    //20190611 ghk_onpclean
    Y19 = 25,    
    INR_OnpCleaner_Air = 25,
    Y1A = 26,
    INR_OnpCleaner = 26,
    //
    Y1B = 27,
    /// <summary>
    /// Inrail OCR Air Blow Off / On
    /// </summary>
    INR_OcrAir = 27,
    Y1C = 28,
    Y1D = 29,
    Y1E = 30,
    /// <summary>
    /// Inrail 프로브 (up/down)
    /// </summary>
    INR_ProbeDn = 30,
    Y1F = 31,
    /// <summary>
    /// Inrail 프로브 에어(off/on)
    /// </summary>
    INR_ProbeAir = 31,
    Y20 = 32,
    /// <summary>
    /// Loader Picker 회전각도 0도 Cylinder (Table과 같은 방향)
    /// </summary>
    ONP_Rotate0 = 32,
    Y21 = 33,
    /// <summary>
    /// Loader Picker 회전각도 90도 Cylinder (Table 모양에서 90도 회전한 방향)
    /// </summary>
    ONP_Rotate90 = 33,
    Y22 = 34,
    /// <summary>
    /// Loader Picker Vacuum 1 (자재 흡착)
    /// </summary>
    ONP_Vacuum1 = 34,
    Y23 = 35,
    /// <summary>
    /// Loader Picker Vacuum 2 (자재 흡착)
    /// </summary>
    ONP_Vacuum2 = 35,
    Y24 = 36,
    /// <summary>
    /// Loader Picker Ejector (자재 배출)
    /// </summary>
    ONP_Ejector = 36,
    Y25 = 37,
    /// <summary>
    /// Loader Picker Drain (물 흡입)
    /// </summary>
    ONP_Drain = 37,
    Y26 = 38,
    Y27 = 39,
    Y28 = 40,
    /// <summary>
    /// Grind Door Lock (장비 전, 후면에 있는 문 잠금)
    /// </summary>
    GRD_DoorLock = 40,
    Y29 = 41,
    Y2A = 42,
    Y2B = 43,
    Y2C = 44,
    /// <summary>
    /// Grind Front Water (Grind Zone 전면에서 물 나오는 곳)
    /// </summary>
    GRD_FrontWater = 44,
    Y2D = 45,
    Y2E = 46,
    /// <summary>
    /// Grind Left Wheel Cleaner (Water on/off)
    /// </summary>
    GRDL_WhlCleaner = 46,
    Y2F = 47,
    /// <summary>
    /// Grind Right Wheel Cleaner (Water on/off)
    /// </summary>
    GRDR_WhlCleaner = 47,
    Y30 = 48,
    /// <summary>
    /// Grind Left Table Ejector (자재 배출)
    /// </summary>
    GRDL_TbEjector = 48,
    Y31 = 49,
    /// <summary>
    /// Grind Left Table Vacuum (자재 흡착)
    /// </summary>
    GRDL_TbVacuum = 49,
    Y32 = 50,
    /// <summary>
    /// Grind Left Table Flow (Left Table에서 Water on/off)
    /// </summary>
    GRDL_TbFlow = 50,
    Y33 = 51,
    /// <summary>
    /// Grind Left Top Cleaner Down Cylinder (up/down)
    /// </summary>
    GRDL_TopClnDn = 51,
    Y34 = 52,
    /// <summary>
    /// Grind Left Top Cleaner Air Cylinder (Top Cleaner에서 Air on/off)
    /// </summary>
    GRDL_TopClnAir = 52,
    Y35 = 53,
    /// <summary>
    /// Grind Left Top Cleaner Flow (Water on/off)
    /// </summary>
    GRDL_TopClnFlow = 53,
    Y36 = 54,
    /// <summary>
    /// Grind Left Top Cleaner Water Knife 
    /// </summary>
    GRDL_TopWaterKnife = 54,
    Y37 = 55,
    Y38 = 56,
    /// <summary>
    /// Grind Left Probe Sensor Down Cylinder (up/down)
    /// </summary>
    GRDL_ProbeDn = 56,
    Y39 = 57,
    /// <summary>
    /// Grind Left Probe Sensor Air Cylinder on/off (프로브 센서가 높이 측정 시 측정 위치 물기 제거)
    /// </summary>
    GRDL_ProbeAir = 57,
	Y3A = 58,
    /// <summary>
    /// Grind Left Probe Ejector on/off : P/G 시작 시 상시 On, 종료 시 Off(Only 2000X)
    /// </summary>
    GRDL_ProbeEjector = 58,  //Y3A = 58,     // 2020.09.16 SungTae 
    Y3B = 59,
    /// <summary>
    /// Carrier Vacuum Off/On Left Table
    /// </summary>
    GRDL_CarrierVacuum = 59,
    Y3C = 60,
    /// <summary>
    /// Grind Left Spindle Inverter MC on/off (Inverter 전원)
    /// </summary>
    GRDL_SplInverterMC = 60,
    Y3D = 61,
    /// <summary>
    /// Grind Left Spindle Cooling Air on/off
    /// </summary>
    GRDL_SplCDA = 61,
    Y3E = 62,
    /// <summary>
    /// Grind Left Spindle PCW on/off (스핀들 냉각수)
    /// </summary>
    GRDL_SplPCW = 62,
    Y3F = 63,
    /// <summary>
    /// Unit #1 Vacuum Off/On Left Table (U 전용)
    /// </summary>
    GRDL_Unit_1_Vacuum = 63,
    Y40 = 64,
    /// <summary>
    /// Grind Left Spindle Water on/off 
    /// </summary>
    GRDL_SplWater = 64,
    Y41 = 65,
    /// <summary>
    /// Unit #2 Vacuum Off/On Left Table (U 전용)
    /// </summary>
    GRDL_Unit_2_Vacuum = 65,
    Y42 = 66,
    /// <summary>
    /// Grind Left Spindle Bottom Water on/off
    /// </summary>
    GRDL_SplBtmWater = 66,
    Y43 = 67,
    /// <summary>
    /// Unit #3 Vacuum Off/On Left Table (U 전용)
    /// </summary>
    GRDL_Unit_3_Vacuum = 67,
    Y44 = 68,
    /// <summary>
    /// Unit #4 Vacuum Off/On Left Table (U 전용)
    /// </summary>
    GRDL_Unit_4_Vacuum = 68,
    Y45 = 69,
    Y46 = 70,
    Y47 = 71,
    Y48 = 72,
    /// <summary>
    /// Grind Right Table Ejector (자재 배출)
    /// </summary>
    GRDR_TbEjector = 72,
    Y49 = 73,
    /// <summary>
    /// Grind Right Table Vacuum (자재 흡착)
    /// </summary>
    GRDR_TbVacuum = 73,
    Y4A = 74,
    /// <summary>
    /// Grind Right Table Flow (Water on/off)
    /// </summary>
    GRDR_TbFlow = 74,
    Y4B = 75,
    /// <summary>
    /// Grind Right Top Cleaner Dowm Cylinder (up/down)
    /// </summary>
    GRDR_TopClnDn = 75,
    Y4C = 76,
    /// <summary>
    /// Grind Right Top Cleaner Air on/off
    /// </summary>
    GRDR_TopClnAir = 76,
    Y4D = 77,
    /// <summary>
    /// Grind Right Top Cleaner Flow (Water on/off)
    /// </summary>
    GRDR_TopClnFlow = 77,
    Y4E = 78,
    /// <summary>
    /// Grind Right Top Cleaner Water Knife
    /// </summary>
    GRDR_TopWaterKnife = 78,
    Y4F = 79,
    Y50 = 80,
    /// <summary>
    /// Grind Right Probe Down Cylinder (up/down)
    /// </summary>
    GRDR_ProbeDn = 80,
    Y51 = 81,
    /// <summary>
    /// Grind Right Probe Sensor Air Cylinder on/off (프로브 센서가 높이 측정 시 측정 위치 물기 제거)
    /// </summary>
    GRDR_ProbeAir = 81,
	Y52 = 82,
    /// <summary>
    /// Grind Right Probe Ejector on/off : P/G 시작 시 상시 On, 종료 시 Off(Only 2000X)
    /// </summary>
    GRDR_ProbeEjector = 82,  //Y52 = 82,     // 2020.09.16 SungTae
    Y53 = 83,
    /// <summary>
    /// Carrier Vacuum Off/On Right Table
    /// </summary>
    GRDR_CarrierVacuum = 83,
    Y54 = 84,
    /// <summary>
    /// Grind Right Spindle Inverter MC on/off (Inverter 전원)
    /// </summary>
    GRDR_SplInverterMC = 84,
    Y55 = 85,
    /// <summary>
    /// Grind Right Spindle Cooling Air on/off
    /// </summary>
    GRDR_SplCDA = 85,
    Y56 = 86,
    /// <summary>
    /// Grind Right Spindle PCW on/off (스핀들 냉각수)
    /// </summary>
    GRDR_SplPCW = 86,
    Y57 = 87,
    /// <summary>
    /// Unit #1 Vacuum Right Table (U 전용)
    /// </summary>
    GRDR_Unit_1_Vacuum = 87,
    Y58 = 88,
    /// <summary>
    /// Grind Right Spindle Water on/off 
    /// </summary>
    GRDR_SplWater = 88,
    Y59 = 89,
    /// <summary>
    /// Unit #2 Vacuum Right Table (U 전용)
    /// </summary>
    GRDR_Unit_2_Vacuum = 89, 
    Y5A = 90,
    /// <summary>
    /// Grind Right Spindle Bottom Water on/off
    /// </summary>
    GRDR_SplBtmWater = 90,
    Y5B = 91,
    /// <summary>
    /// Unit #3 Vacuum Right Table (U 전용)
    /// </summary>
    GRDR_Unit_3_Vacuum = 91,
    Y5C = 92,
    /// <summary>
    /// Unit #4 Vacuum Right Table (U 전용)
    /// </summary>
    GRDR_Unit_4_Vacuum = 92,
    Y5D = 93,
    Y5E = 94,
    Y5F = 95,
    Y60 = 96,
    /// <summary>
    /// Unloader Picker 회전각도 0도 Cylinder (Table과 같은 방향)
    /// </summary>
    OFFP_Rotate0 = 96,
    Y61 = 97,
    /// <summary>
    /// Unloader Picker 회전각도 90도 Cylinder (Table 모양에서 90도 회전한 방향)
    /// </summary>
    OFFP_Rotate90 = 97,
    Y62 = 98,
    /// <summary>
    /// Unloader Picker Vacuum 1 (자재 흡착)
    /// </summary>
    OFFP_Vacuum1 = 98,
    Y63 = 99,
    /// <summary>
    /// Unloader Picker Vacuum 2 (자재 흡착)
    /// </summary>
    OFFP_Vacuum2 = 99,
    Y64 = 100,
    /// <summary>
    /// Unloader Ejector (자재 배출)
    /// </summary>
    OFFP_Ejector = 100,
    Y65 = 101,
    /// <summary>
    /// Unloader Picker Drain (물 흡입)
    /// </summary>
    OFFP_Drain = 101,
    Y66 = 102,
    Y67 = 103,
    Y68 = 104,
    Y69 = 105,
    Y6A = 106,
    /// <summary>
    /// Dry Top Air on/off 
    /// </summary>
    DRY_TopAir = 106,
    Y6B = 107,
    /// <summary>
    /// Dry Bottom Air on/off
    /// </summary>
    DRY_BtmAir = 107,
    Y6C = 108,
    /// <summary>
    /// Dry Bottom Standby Position Cylinder (Dry Bottom Cleaner를 Standby Position으로 이동하게 하는 실린더)
    /// </summary>
    DRY_BtmStandbyPos = 108,
    /// <summary>
    /// Dry cover open (only U)
    /// </summary>
    DRY_CoverOpen = 108,
    Y6D = 109,
    /// <summary>
    /// Dry Bottom Target Position Cylinder (Dry Bottom Cleaner를 Target Position으로 이동하게 하는 실린더)
    /// </summary>
    DRY_BtmTargetPos = 109,
    /// <summary>
    /// Dry cover close (only U)
    /// </summary>
    DRY_CoverClose = 109,
    Y6E = 110,
    /// <summary>
    /// Dry Out Rail Air Cylinder(자재가 Dry Zone에서 Unloader MGZ으로 이동할 때 자재 윗면에 Air를 배출하는 실린더)
    /// </summary>
    DRY_OutRailAir = 110,
    /// <summary>
    /// Dry Unit Sensor Check시 Air 출력 (Only U)
    /// </summary>
    DRY_CheckAir = 110,
    Y6F = 111,
    /// <summary>
    /// Dry Cleaner Bottom Flow (Dry Cleaner Bottom에서 Water on/off)
    /// </summary>
    DRY_ClnBtmFlow = 111,
    Y70 = 112,
    /// <summary>
    /// Left Pump Run (왼쪽 펌프 가동)
    /// </summary>
    PUMPL_Run = 112,
    Y71 = 113,
    Y72 = 114,
    Y73 = 115,
    Y74 = 116,
    Y75 = 117,
    Y76 = 118,
    /// <summary>
    /// Right Pump Run (오른쪽 펌프 가동)
    /// </summary>
    PUMPR_Run = 118,
    Y77 = 119,
    Y78 = 120,
    Y79 = 121,
    Y7A = 122,
    Y7B = 123,
    Y7C = 124, IOZL_Power = 124, //InRail
    Y7D = 125, IOZR_Power = 125, //Dry
    Y7E = 126, IOZT_Power = 126, //Table
    Y7F = 127, IOZO_Power = 125, //OutRail
    Y80 = 128, TNK_1_1 = 128,
    Y81 = 129, TNK_1_2 = 129,
    Y82 = 130, TNK_1_4 = 130,
    Y83 = 131, TNK_1_8 = 131,
    Y84 = 132, TNK_10_1 = 132,
    Y85 = 133, TNK_10_2 = 133,
    Y86 = 134, TNK_10_4 = 134,
    Y87 = 135, TNK_10_8 = 135,
    Y88 = 136, TNK_100_1 = 136,
    Y89 = 137,
    Y8A = 138,
    Y8B = 139,
    Y8C = 140,
    Y8D = 141,
    Y8E = 142,
    Y8F = 143,
    Y90 = 144,
    /// <summary>
    /// Loader Belt Run Button Lamp (Loader 왼쪽면)
    /// </summary>
    ONL_BtnBeltRun = 144,
    Y91 = 145,
    Y92 = 146,
    Y93 = 147,
    Y94 = 148,
    /// <summary>
    /// Loader Door Lock (Loader Front/Left/Rear Door 잠금)
    /// </summary>
    ONL_DoorLock = 148,
    Y95 = 149,
    Y96 = 150,
    Y97 = 151,
    Y98 = 152,
    Y99 = 153,
    Y9A = 154,
    Y9B = 155,
    Y9C = 156,
    /// <summary>
    /// Loader Top Conveyor Belt Run (Top Conveyor Belt 가동)
    /// </summary>
    ONL_TopBeltRun = 156,
    Y9D = 157,
    Y9E = 158,
    Y9F = 159,
    YA0 = 160,
    /// <summary>
    /// Loader Bottom Conveyor Belt Run (Bottom Conveyor Belt 가동)
    /// </summary>
    ONL_BtmBeltRun = 160,
    YA1 = 161,
    /// <summary>
    /// Loader Bottom Conveyor Belt CCW (Bottom Conveyor Belt 회전 방향 리버스)
    /// </summary>
    ONL_BtmBeltCCW = 161,
    YA2 = 162,
    YA3 = 163,
    YA4 = 164,
    YA5 = 165,
    /// <summary>
    /// Loader Pusher Forward Cylinder (Pusher Forward/Backward)
    /// </summary>
    ONL_PusherForward = 165,
    YA6 = 166,
    YA7 = 167,
    YA8 = 168,
    YA9 = 169,
    YAA = 170,
    /// <summary>
    /// Loader Clamp On Cylinder (Clamp Down)
    /// </summary>
    ONL_ClampOn = 170,
    YAB = 171,
    /// <summary>
    /// Loader Clamp Off Cylinder (Clamp Up)
    /// </summary>
    ONL_ClampOff = 171,
    YAC = 172,
    YAD = 173,
    YAE = 174,
    YAF = 175,
    YB0 = 176,
    /// <summary>
    /// Unloader Top Belt Run Button Lamp (Unloader 오른쪽면)
    /// </summary>
    OFFL_BtnBeltTopRun = 176,
    YB1 = 177,
    /// <summary>
    /// Offlaoder Bottom Belt Run Button Lamp (Unloader 오른쪽면)
    /// </summary>
    OFFL_BtnBeltBtmRun = 177,
    YB2 = 178,
    YB3 = 179,
    YB4 = 180,
    /// <summary>
    /// Unloader Door Lock (Offlaoder Front/Right/Rear Door 잠금)
    /// </summary>
    OFFL_DoorLock = 180,
    YB5 = 181,
    YB6 = 182,
    YB7 = 183,
    YB8 = 184,
    /// <summary>
    /// Unloader Top Conveyor Belt Run (Top Conveyor Belt 가동)
    /// </summary>
    OFFL_TopBeltRun = 184,
    YB9 = 185,
    YBA = 186,
    YBB = 187,
    /// <summary>
    /// Unloader Middle Conveyor Belt Run (Middle Conveyor Belt 가동)
    /// </summary>
    OFFL_MidBeltRun = 187,
    YBC = 188,
    /// <summary>
    /// Unloader Middle Conveyor Belt CCW (Middle Conveyor Belt 회전방향 리버스)
    /// </summary>
    OFFL_MidBeltCCW = 188,
    YBD = 189,
    YBE = 190,
    /// <summary>
    /// Unloader Bottom Conveyor Belt Run (Bottom Conveyer Belt 가동)
    /// </summary>
    OFFL_BtmBeltRun = 190,
    YBF = 191,
    YC0 = 192,
    YC1 = 193,
    YC2 = 194,
    /// <summary>
    /// Unloader Top MGZ Up Cylinder 
    /// </summary>
    OFFL_TopMGZUp = 194,
    YC3 = 195,
    /// <summary>
    /// Unloader Top MGZ Down Cylinder
    /// </summary>
    OFFL_TopMGZDn = 195,
    YC4 = 196,
    /// <summary>
    /// Unloader Top Clamp On Cylinder (Top Clamp Down)
    /// </summary>
    OFFL_TopClampOn = 196,
    YC5 = 197,
    /// <summary>
    /// Unloader Top Clamp Off Cylinder (Top Clamp Up)
    /// </summary>
    OFFL_TopClampOff = 197,
    YC6 = 198,
    YC7 = 199,
    YC8 = 200,
    YC9 = 201,
    YCA = 202,
    /// <summary>
    /// Unloader Bottom MGZ Up Cylinder
    /// </summary>
    OFFL_BtmMGZUp = 202,
    YCB = 203,
    /// <summary>
    /// Unloader Bottom MGZ Down Cylinder
    /// </summary>
    OFFL_BtmMGZDn = 203,
    YCC = 204,
    /// <summary>
    /// Unloader Bottom Clamp On Cylinder (Bottom Clamp Down)
    /// </summary>
    OFFL_BtmClampOn = 204,
    YCD = 205,
    /// <summary>
    /// Unloader Bottom Clamp Off Cylinder (Bottom Clamp Up)
    /// </summary>
    OFFL_BtmClampOff = 205,
    YCE = 206,
    YCF = 207
}
#endregion

public enum ELang
{
    English = 0,
    Chinese = 1,
    Korean = 2,
}

public enum EUser
{
    Operator  ,
    Technician,
    Engineer  ,
    Master
}

public enum eMsg
{
    Notice,
    Warning,
    Error
}
