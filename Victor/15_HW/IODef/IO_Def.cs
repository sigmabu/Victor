namespace Victor
{
    /// <summary>
    /// IO list define
    /// </summary>
    public enum eIn
    {
        None = 0,

        #region Machine Default Input

        EMO_SWITCH_X000 = 10000,
        MAIN_SWITCH_X001 = 10001,
        START_SWITCH_X002 = 10002,
        STOP_SWITCH_X003 = 10003,
        RESET_SWITCH_X004 = 10004,
        MANUAL_SWITCH_X005 = 10005,
        MAIN_DOOR_X006 = 10006,
        LEFT_DOOR_X007 = 10007,

        REGHT_DOOR_X008 = 10008,
        REAR_DOOR_X009 = 10009,
        MAIN_AIR00_X00A = 100010,
        MAIN_AIR01_X00B = 100011,
        MAIN_AIR02_X00C = 100012,
        MAIN_POWER00_X00D = 100013,
        MAIN_POWER01_X00E = 100014,
        MAIN_POWER02_X00F = 100015,

        MAIN_READY_X010 = 100016,
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

