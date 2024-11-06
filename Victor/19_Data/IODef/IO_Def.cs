namespace Victor
{
    /// <summary>
    /// IO list define
    /// </summary>
    public enum eIn :uint
    {
        None = 0,

        #region Machine Default Input

        EMO_SWITCH_X000     = 0x0000,
        MAIN_SWITCH_X001    = 0x0001,
        START_SWITCH_X002   = 0x0002,
        STOP_SWITCH_X003    = 0x0003,
        RESET_SWITCH_X004   = 0x0004,
        MANUAL_SWITCH_X005  = 0x0005,
        MAIN_DOOR_X006      = 0x0006,
        LEFT_DOOR_X007      = 0x0007,

        REGHT_DOOR_X008     = 0x0008,
        REAR_DOOR_X009      = 0x0009,
        MAIN_AIR00_X00A     = 0x000A,
        MAIN_AIR01_X00B     = 0x000B,
        MAIN_AIR02_X00C     = 0x000C,
        MAIN_POWER00_X00D   = 0x000D,
        MAIN_POWER01_X00E   = 0x000E,
        MAIN_POWER02_X00F   = 0x000F,

        MAIN_READY_X010 = 0x00010,
        MAIN_READY_X011 = 0x00011,
        MAIN_READY_X012 = 0x00012,
        MAIN_READY_X013 = 0x00013,
        MAIN_READY_X014 = 0x00024,
        MAIN_READY_X015 = 0x00015,
        MAIN_READY_X016 = 0x00016,
        MAIN_READY_X017 = 0x00017,
        MAIN_READY_X018 = 0x00018,
        MAIN_READY_X019 = 0x00019,
        MAIN_READY_X01A = 0x0001A,
        #endregion
        END
    }
    public enum eOut
    {
        None = 0,

        #region Machine Default Input

        EMO_SWITCH_Y000 = 20000,
        MAIN_SWITCH_Y001 = 20001,
        START_SWITCH_Y002 = 20002,
        STOP_SWITCH_Y003 = 20003,
        RESET_SWITCH_Y004 = 20004,
        MANUAL_SWITCH_Y005 = 20005,
        MAIN_DOOR_Y006 = 20006,
        LEFT_DOOR_Y007 = 20007,

        REGHT_DOOR_Y008 = 20008,
        REAR_DOOR_Y009 = 20009,
        MAIN_AIR00_Y00A = 200010,
        MAIN_AIR01_Y00B = 200011,
        MAIN_AIR02_Y00C = 200012,
        MAIN_POWER00_Y00D = 200013,
        MAIN_POWER01_Y00E = 200014,
        MAIN_POWER02_Y00F = 200015,

        MAIN_READY_Y010 = 200016,
        #endregion
        END


    }

    public enum eSet
    {
        Off = 0,
        On = 1,
    }

    public enum eSolCmd
    {
        Zero = 0,       // 모두 Off
        Set = 1,
        Check = 2,
    }
}

