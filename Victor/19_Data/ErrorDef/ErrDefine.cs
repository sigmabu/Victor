﻿namespace Victor
{
    /// <summary>
    /// Error list
    /// </summary>
    /// 

    public enum eErr
    {
        NONE = 000000,

        // System Error 010000 ~ 019999
        SYS_ERROR = 010000,
        SYS_EMG_FRONT_LEFT,
        SYS_EMG_FRONT_RIGHT,
        SYS_EMG_REAR_LEFT,
        SYS_EMG_REAR_RIGHT,
        SYS_MAIN_VACUUM_OFF_CHECK,
        SYS_WHEEL_FILE_NOT_SELECT,
        SYS_WHEEL_FILE_SAVE_ERROR,
        SYS_LEAKAGE_01_CHECK_ERROR,
        SYS_LEAKAGE_02_CHECK_ERROR,
        SYS_LEAKAGE_03_CHECK_ERROR,
        SYS_LEAKAGE_04_CHECK_ERROR,
        SYS_LEAKAGE_05_CHECK_ERROR,
        SYS_LEAKAGE_06_CHECK_ERROR,
        SYS_LEAKAGE_07_CHECK_ERROR,

        // Stage2 Error 320000 ~ 329999
        STAG2_ERROR = 320000,
        STAGE_2_SERVO_ON_TIMEOUT_ERROR,
        STAGE_2_HOMING_TIMEOUT_ERROR,
        STAGE_2_WARMUP_TIMEOUT_ERROR,
        STAGE_2_WAFER_GRINDING_TIMEOUT_ERROR,
        STAGE_2_DRESSING_TIMEOUT_ERROR,
        STAGE_2_TABLE_GRINDING_TIMEOUT_ERROR,
        STAGE_2_WHEEL_ZIG_NOT_CHECK_ERROR,
        STAGE_2_WHEEL_TOOLSETTER_ON_ERROR,
        STAGE_2_WHEEL_TOOLSETTER_OFF_ERROR,
        STAGE_2_WHEEL_TOOLSETTER_DETECT_FIND_LIMIT_ERROR,
        STAGE_2_WHEEL_TOOLSETTER_ESCAPE_DOWN_LIMIT_ERROR,
        STAGE_2_DRESS_TOOLSETTER_ON_ERROR,
        STAGE_2_DRESS_TOOLSETTER_OFF_ERROR,
        STAGE_2_DRESS_TOOLSETTER_DETECT_FIND_LIMIT_ERROR,
        STAGE_2_DRESS_TOOLSETTER_ESCAPE_DOWN_LIMIT_ERROR,

        STAGE_2_PUMP_ERROR,//
        STAGE_2_PUMP_LOW_ERROR,
        STAGE_2_PUMP_HIGH_ERROR,
        STAGE_2_PUMP_OVERLOAD_ERROR,
        STAGE_2_PUMP_RUN_TIMEOUT,
        STAGE_2_ADD_PUMP_RUN_TIMEOUT,
        STAGE_2_HIGH_PUMP_ALARM_ERROR,
        STAGE_2_HIGH_PUMP_RUN_TIMEOUT,

        STAGE_2_WATER_ERROR,//
        STAGE_2_TABLE_WATER_NOT_ON_ERROR,
        STAGE_2_TABLE_WATER_NOT_OFF_ERROR,
        STAGE_2_EJECT_ON_CHECK_ERROR,
        STAGE_2_EJECT_OFF_CHECK_ERROR,
        STAGE_2_VAC_ON_CHECK_ERROR,
        STAGE_2_VAC_OFF_CHECK_ERROR,

        STAGE_2_CLEAN_ERROR,//
        STAGE_2_TOPCLEAN_AIRKNIFE_NOT_ON_ERROR,
        STAGE_2_TOPCLEAN_AIRKNIFE_NOT_OFF_ERROR,
        STAGE_2_TOPCLEAN_WATER_NOT_ON_ERROR,
        STAGE_2_TOPCLEAN_WATER_NOT_OFF_ERROR,
        STAGE_2_TOPCLEAN_WATERKNIFE_NOT_ON_ERROR,
        STAGE_2_TOPCLEAN_WATERKNIFE_NOT_OFF_ERROR,

        STAGE_2_WHEEL_CLEAN_ERROR,//
        STAGE_2_WATER_NOT_ON_CHECK_ERROR,
        STAGE_2_WATER_NOT_OFF_CHECK_ERROR,
        STAGE_2_WHEELSPINDLE_COLLANT_NOT_OPEN_ERROR,
        STAGE_2_DTS_AIRBLOW_NOT_OPEN_ERROR,
        STAGE_2_FRONT_WATERNOZZLE_NOT_OPEN_ERROR,
        STAGE_2_REAR_WATERNOZZLE_NOT_OPEN_ERROR,
        STAGE_2_WHEELTIP_CLEANNOZZLE_NOT_OPEN_ERROR,

        STAGE_2_TABLE_CLEAN_ERROR,//
        STAGE_2_WAFER_CLEAN_TIMEOUT_ERROR,
        STAGE_2_TABLE_CLEAN_TIMEOUT_ERROR,
        STAGE_2_WAIT_POSITION_TIMEOUT_ERROR,
        STAGE_2_GRIND_Z_AXIS_WORK_POSITION_CALCULATION_ERROR,

        STAGE_2_WHEEL_THICKNESS_ERROR,//
        STAGE_2_WHEEL_THICKNESS_LIMIT_OVER_ERROR,
        STAGE_2_WHEEL_NEED_TO_CHANGE_ERROR,
        STAGE_2_DRESS_THICKNESS_ERROR,//
        STAGE_2_DRESSER_THICKNESS_LIMIT_OVER_ERROR,
        STAGE_2_DRESSER_NEED_TO_CHANGE_ERROR,
        STAGE_2_WHEEL_WAFER_NOT_CONTACT_ERROR,

        STAGE_2_RECIPE_ERROR,//
        STAGE_2_TABLE_RECIPE_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_TABLE_RECIPE_WTS_GAP_SET_LIMIT_ERROR,
        STAGE_2_TABLE_RECIPE_DTS_GAP_SET_LIMIT_ERROR,
        STAGE_2_DRESS_RECIPE_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_WAFER_TOPDOWN_RECIPE_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_WAFER_TOPDOWN_TOTAL_RECIPE_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_WAFER_TARGET_TOTAL_RECIPE_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_WAFER_TARGET_GRINDING_LIMIT_OVER_ERROR,
        STAGE_2_WHEEL_DIAMETER_INFORMATION_ABNORMAL_ERROR,

        STAGE_2_DRESSING_WHEEL_LOSS_LOW_ERROR,
        STAGE_2_DRESSING_LOSS_LIMIT_OVER_ERROR,

        STAGE_2_IPG_ERROR,//
        STAGE_2_IPG_WATER_NOT_ON_ERROR,
        STAGE_2_IPG_WATER_NOT_OFF_ERROR,

        STAGE_2_IPG_UP_ERROR,
        STAGE_2_IPG_NOT_UP_ERROR,
        STAGE_2_IPG_NOT_DOWN_ERROR,
        STAGE_2_IPG_DOWN_ERROR,
        STAGE_2_IPG_ALARM_ERROR,

        STAGE_2_IPG_IBM_UPDOWN_VALUE_INVALID_ERROR,
        STAGE_2_IPG_IBM_UP_VALUE_INVALID_ERROR,
        STAGE_2_IPG_IBM_DOWN_VALUE_INVALID_ERROR,
        STAGE_2_IPG_IBO_UPDOWN_VALUE_INVALID_ERROR,
        STAGE_2_IPG_IBO_UP_VALUE_INVALID_ERROR,
        STAGE_2_IPG_IBO_DOWN_VALUE_INVALID_ERROR,

        STAGE_2_IPG_IBM_TABLE_THICK_LOW_MEASURE_ERROR,
        STAGE_2_IPG_IBO_TABLE_THICK_LOW_MEASURE_ERROR,

        STAGE_2_FLOWMETER_ERROR,//
        STAGE_2_WHEEL_SPINDLE_CDA_AIR_01_NOT_ON_ERROR,
        STAGE_2_WHEEL_SPINDLE_CDA_AIR_02_NOT_ON_ERROR,
        STAGE_2_WHEEL_SPINDLE_CDA_AIR_03_NOT_ON_ERROR,

        STAGE_2_WHEEL_SPINDLE_CDA_AIR_01_FLOW_NOT_ON_ERROR,
        STAGE_2_WHEEL_SPINDLE_CDA_AIR_02_FLOW_NOT_ON_ERROR,
        STAGE_2_WHEEL_SPINDLE_CDA_AIR_03_FLOW_NOT_ON_ERROR,

        STAGE_2_CDA_NOT_OPEN_ERROR,
        STAGE_2_CDA_NOT_CLOSE_ERROR,
        STAGE_2_CDA1_FLOW_NOT_OPEN_ERROR,
        STAGE_2_CDA2_FLOW_NOT_OPEN_ERROR,

        STAGE_2_CHUCK_TABLE_PCW_NOT_ON_ERROR,
        STAGE_2_CHUCK_TABLE_PCW_FLOW_NOT_ON_ERROR,
        STAGE_2_DRESS_PCW_NOT_ON_ERROR,
        STAGE_2_DRESS_PCW_NOT_ON_FLOW_ERROR,
        STAGE_2_WHEEL_SPINDLE_PCW_NOT_ON_ERROR,
        STAGE_2_WHEEL_SPINDLE_PCW_FLOW_NOT_ON_ERROR,

        STAGE_2_PCW_OFF_ERROR,
        STAGE_2_PCW_TEMP_RANGEOVER_ERROR,
        STAGE_2_DIW1_TEMP_RANGEOVER_ERROR,
        STAGE_2_DIW2_TEMP_RANGEOVER_ERROR,

        STAGE_2_TABLE_VACUUM_8_INCH_NOT_ON_ERROR,
        STAGE_2_TABLE_VACUUM_8_INCH_NOT_OFF_ERROR,

        STAGE_2_TABLE_VACUUM_12_INCH_NOT_ON_ERROR,
        STAGE_2_TABLE_VACUUM_12_INCH_NOT_OFF_ERROR,

        STAGE_2_FRONT_NOZZLE_NOT_OPEN_ERROR,
        STAGE_2_FRONT_NOZZLE_NOT_CLOSE_ERROR,
        STAGE_2_REAR_NOZZLE_NOT_OPEN_ERROR,
        STAGE_2_REAR_NOZZLE_NOT_CLOSE_ERROR,
        STAGE_2_HIGH_PRESSURE_NOZZLE_NOT_OPEN_ERROR,
        STAGE_2_HIGH_PRESSURE_NOZZLE_NOT_CLOSE_ERROR,

        STAGE_2_WAFER_LOAD_THICKNESS_LOW_ERROR,
        STAGE_2_WAFER_N_IPGBASE_DIFF_VALUE_LOW_ERROR,

        STAGE_2_WAFER_ERROR,//
        STAGE_2_WAFER_IS_EXIST,
        STAGE_2_WAFER_IS_NOT_EXIST,

        STAGE_2_SPINDLE_OVERLOAD_ERROR,

        STAGE_2_REGENERATIVE_RESISTANCE_THERMAL_CHECK_ERROR,
        STAG2_ERROR_END,

        End

    }

    /// <summary>
    /// Alarm list [ 설비 가동에 치명적이지 않은 확인 내용]
    /// </summary>
    public enum eAlarm
    {
        NONE = 000000,
        LOAD_STOP_ALARM,
        DOOR_LOCK_SKIP_ALARM,
        GRD_DoorFront_OPEN,
        GRD_DoorRear_OPEN,

        LDR_DoorFront_OPEN,
        LDR_DoorLeft_OPEN,
        LDR_DoorRear_OPEN,

        ULD_DoorFront_OPEN,
        ULD_DoorRight_OPEN,
        ULD_DoorRear_OPEN,

        LIGHT_CURTAIN_SKIP_ALARM,

        LDR_LightCurtain_DETECT_ALARM,
        UDR_LightCurtain_DETECT_ALARM,

        LDR_mVgazine_Empty,
        Work_Finish,

        STAG1_WHEEL_LIMIT_ALARM,
        STAG1_DRESSER_LIMIT_ALARM,
        STAG2_WHEEL_LIMIT_ALARM,
        STAG2_DRESSER_LIMIT_ALARM,

        MOTION_LINK_ERROR,                  // 아진 보드의 M3 링크가 끊어졌다. EMG 버튼이 눌린 상태일 수도 있다.
    }
}