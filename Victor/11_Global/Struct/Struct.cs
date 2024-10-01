
using SW21;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;

public class TLotInfo
{
    public string sLotName;
    public int iTotalMgz;
    public int iTotalStrip;//koo : Qorvo Lot Rework
    public bool bLotOpen; //ksg
    public bool bLotEnd; //ksg
    public string sLToolId; //190802 ksg : Tool Id & Dresser Id
    public string sRToolId; //190802 ksg : Tool Id & Dresser Id
    public string sLTool_Serial_Num; //200628 LCY 현재 Wheel Serial Num
    public string sRTool_Serial_Num; //200628 LCY 현재 Wheel Serial Num
    public string sCurr_LToolId; //191113 LCY 현재 Tool ID
    public string sCurr_RToolId; //191113 LCY 현재 Tool ID

    public string sLDrsId; //190802 ksg : Tool Id & Dresser Id
    public string sRDrsId; //190802 ksg : Tool Id & Dresser Id
    public string sCurr_LDrsId; //191113 LCY 현재 Dress ID
    public string sCurr_RDrsId; //191113 LCY 현재 Dress ID
    public string sGMgzId; //191023 ksg : Good Magazine Id

    public string sNMgzId; //191023 ksg : NG Magazine Id
}





#region Spindle
public struct tSplData
{
    public BitArray aStat;
    public int iRpm;
    public string sErr;
    public double dLoad;
    public double dTemp_Val;
    public int nCurrent_Amp;
    public double nChuck_Vacuum;
};
#endregion

#region Barcode
public struct tBcr
{
    public bool bRun; //BCR & OCR & Ori 실행 상태
    public bool bCon; //연결 상태                    //190211 ksg : 추가 항목 
    public bool bRet; //Bcr 읽은 결과 
    public bool bRetOri; //Ori 읽은 결과                //190211 ksg : 추가 항목 
    public bool bRetTOri; //Table Ori 읽은 결과          //200118 ksg : 추가 항목 
    public bool bRetOcr; //Ocr 읽은 결과                //190309 ksg : 추가 항목 
    public bool bRetCom; //Bcr & Ocr 읽고 비교 결과     //190309 ksg : 추가 항목 
    public bool bRetMark; //Mark 읽은 결과               //190712 ksg : 추가 항목 
    public bool bTrigger; //X의 트리거 0 : 대기, 1 : 측정
    public bool bBcr; //X의 트리거                   //190211 ksg : 추가 항목 
    public bool bOcr; //X의 트리거                   //190309 ksg : 추가 항목 
    public bool bOri; //X의 트리거                   //190211 ksg : 추가 항목 
    public bool bTOri; //X의 트리거                   //200118 ksg : 추가 항목 -> Table Ori 기능 추가
    public bool bMark; //X의 트리거                   //190712 ksg : 추가 항목 
    //--------------------------------------------
    public bool bBcr_Ir; //X의 트리거(Inrail     ) //200129 ksg :
    public bool bOri_Ir; //X의 트리거(Inrail     ) //200129 ksg :
    public bool bOcr_Ir; //X의 트리거(Inrail     ) //200129 ksg :
    public bool bMark_Ir; //X의 트리거(Inrail     ) //200129 ksg :
    public bool bBcr_Gl; //X의 트리거(Left Table ) //200129 ksg :
    public bool bOri_Gl; //X의 트리거(Left Table ) //200129 ksg :
    public bool bOcr_Gl; //X의 트리거(Left Table ) //200129 ksg :
    public bool bMark_Gl; //X의 트리거(Left Table ) //200129 ksg :
    public bool bBcr_Gr; //X의 트리거(Right Table) //200129 ksg :
    public bool bOri_Gr; //X의 트리거(Right Table) //200129 ksg :
    public bool bOcr_Gr; //X의 트리거(Right Table) //200129 ksg :
    public bool bMark_Gr; //X의 트리거(Right Table) //200129 ksg :
    //--------------------------------------------
    public string sBcr; //Bcr 읽은 String
    public string sOcr; //Ocr 읽은 String              //190309 ksg : 추가 항목 
    public string sDX; //190211 ksg : 추가 항목 
    public string sBCR; //190211 ksg : 추가 항목 
    public bool bStatusBcr; //190827 ksg : 추가 항목, Bcr 상태
    //--------------------------------------------
    //20200311 jhc : UDP Interface for [ Main <<-->> Vision ]
    public int iUserLevel;  //User Level (2D Vision 화면에 표시할 항목 조절 용) : 0=Operator / 1=Technician or Engineer or Master
    public int iUIMode;     //2D Vision 현재 화면 모드 : 0=Auto Mode Window, 1=Training Mode Window
    //
}
//20200608 jhc : KEYENCE BCR (On/Off-로더 매거진 바코드, SPIL)
/// <summary>
/// KEYENCE 바코드 리더와 통신 상태 및 결과 데이터 관리용
/// </summary>
public struct tKeyenceBcr
{
    public eKeyenceBcrTcpStatus eState;     //BCR 동작 상태   : 0=Ready / 1=Command 송신 완료 (Command Response 수신 대기)/ 2=Command Response 수신 (Data 수신 대기) / 3=Data 수신 완료
    public string sCmd;       //Command        : "" / "LON" / "LOFF" / "BCLR"
    public string sCmdResult; //Command Result : "" / "OK" / "ER"
    public string sErrCode;   //Error Code     : "" / "00"~"99" (Command Result가 "ER"인 경우에 함께 수신됨)
    public string sBcr;       //Data Response  : 읽은 바코드 값(LON 전송 -> OK 수신 -> 바코드 수신) / "ERROR"(LON 전송 -> LOF 전송 -> OK LOFF 수신 -> 후 OK Response 전 LOF 전송시)
    public bool bStErr;     //통신 처리 중 Error 발생 상태 : true=에러상태 / false=정상상태
}
#endregion

#region Wheel
public struct tWhl
{
    #region Wheel Information
    /// <summary>
    /// 드레싱 총 카운트
    /// </summary>
    public int iDrsC;
    /// <summary>
    /// Grinding Total Count 
    /// 스트립 그라인딩 총 카운트 [ea]
    /// </summary>
    public int iGtc;
    /// <summary>
    /// Dressing After Grinding Count 
    /// 드레싱 이후 스트립 그라인딩 카운트 [ea]
    /// </summary>
    public int iGdc;
    /// <summary>
    /// Wheel Outer 
    /// 휠의 외경 [mm]
    /// </summary>
    public double dWhlO;
    /// <summary>
    /// 최초 측정 휠 높이 값
    /// </summary>
    public double dWhlFtH;
    /// <summary>
    /// Wheel Tip Height 
    /// 팁의 높이 초기 값 10 [mm]
    /// </summary>
    public double dWhltH;
    /// <summary>
    /// 그라인딩 간의 자재에 따른 보정이 적용된 휠 높이 [mm]
    /// </summary>
    public double dWhlvH;
    /// <summary>
    /// Wheel Total Loss 
    /// 휠 전체적인 로스량 (최초 측정 값 - 현재 높이) [mm]
    /// </summary>
    public double dWhltL;
    /// <summary>
    /// Wheel 1 Strip Loss 
    /// 1장의 스트립의 로스량 [mm]
    /// </summary>
    public double dWhloL;
    /// <summary>
    /// 1 Dressing Loss 
    /// 드레싱 1번당 로스량 [mm]
    /// </summary>
    public double dWhldoL;
    /// <summary>
    /// Dressing Cycle Loss 
    /// 드레싱 사이클 사이의 로스량 (드레싱 끝 이후 높이 - 다음 드레싱 시작 전 높이) [mm]
    /// </summary>
    public double dWhldcL;
    /// <summary>
    /// 측정 전 휠 높이
    /// </summary>
    public double dWhlBf;
    /// <summary>
    /// 측정 후 휠 높이
    /// </summary>
    public double dWhlAf;
    /// <summary>
    /// 휠 리미트
    /// </summary>
    public double dWhlLimit;
    /// <summary>
    /// 드레셔 리미트
    /// </summary>
    public double dDrsLimit;
    /// <summary>
    /// Wheel Name (Serial Number) 
    /// 휠 이름 (시리얼 넘버 - 입력 값) 
    /// </summary>
    public string sWhlName;
    /// <summary>
    /// Wheel File Last Save Date 
    /// 파일의 마지막 수정 날짜
    /// </summary>
    public DateTime dtLast;
    //20190421 ghk_휠 리그라인딩 옵셋
    /// <summary>
    /// 리그라인딩 횟수에 따른 그라인딩 스타트 위치 조정 변수
    /// </summary>
    public double dReGrdOffset;
    /// <summary>
    /// 휠 파트 넘버
    /// </summary>
    public string sPartNo;
    /// <summary>
    /// Mesh 정보
    /// </summary>
    public string sMesh;

    /// <summary>
    /// 210812 : 드레싱 시 휠 마모 최소 한계 설정 (Using)
    /// </summary>
    public double dWhlLossMinLimitU;
    /// <summary>
    /// 210812 : 드레싱 시 휠 마모 최소 한계 설정 (New)
    /// </summary>
    public double dWhlLossMinLimitN;
    /// <summary>
    /// 210812 : 드레싱 시 휠 마모 최소 한계 설정 (Short)
    /// </summary>
    public double dWhlLossMinLimitS;
    
    /// <summary>
    /// 휠 RFID Tag
    /// </summary>
    public string tag;

    #endregion

    #region Dresser Infomation
    /// <summary>
    /// Dresser Outer 
    /// 드레셔 외경 (입력 불가) [mm]
    /// </summary>
    public double dDrsOuter;
    /// <summary>
    /// Dresser Height 
    /// 드레셔 높이 (입력 불가) [mm]
    /// </summary>
    public double dDrsH;
    /// <summary>
    /// Dresser Name 
    /// 드레셔 이름 (입력 값)
    /// </summary>
    public string sDrsName;
    /// <summary>
    /// 측정 전 드레셔 높이
    /// </summary>
    public double dDrsBf;
    /// <summary>
    /// 측정 후 드레셔 높이
    /// </summary>
    public double dDrsAf;
    /// <summary>
    /// Dressing Used Parameter Array 
    /// 사용 중에 사용되는 드레싱 파라메터
    /// </summary>
    public tStep[] aUsedP;
    /// <summary>
    /// Dressing New Parameter Array 
    /// 휠 교체시 사용되는 드레싱 파라메터
    /// </summary>
    public tStep[] aNewP;
    /// <summary>
    /// Dressing Short Parameter Array 
    /// Grinding 종료시 바로 드레싱 파라메터
    /// </summary>
    public tStep[] aShortP;

    #endregion
}
#endregion

#region Setup Position
/// <summary>
/// System Position Struct 시스템 포지션 구조체
/// </summary>
public struct tSyP
{ 
    #region Loader X
    public double LElvX_Wait;
    /// <summary>
    /// 240mm 기준 포지션
    /// </summary>
    public double LElvX_DefAlign;
    #endregion

    #region Loader Y
    public double LElvY_Pick;
    public double LElvY_Place;
    #endregion

    #region Loader Z
    public double LElvZ_Wait;
    public double LElvZ_PickGo;
    public double LElvZ_Clamp;
    public double LElvZ_PickUp;
    public double LElvZ_PlaceGo;
    public double LElvZ_UnClamp;
    public double LElvZ_PlaceDn;
    #endregion

    #region Loader Pusher X
    public double LElvPX_Wait;
    
    #endregion

    #region Loader Rail X
    public double LRilX_Wait;
    #endregion

    #region Loader Rail Y
    public double LRilY_Wait;
    #endregion

    #region Loader Rail Z
    public double RailZ_Up;
    public double RailZ_Down;   //Inrail lift down position
    #endregion

    #region Loader Picker X
    public double LPnpX_Wait;
    public double LPnpX_Place1;
    public double LPnpX_Place2;
    public double LPnpX_Conv; // Conversion position
    #endregion

    #region Loader Picker Z
    public double LPnpZ_Wait;
    public double LPnpZ_Able;
    #endregion

    #region Loader Picker Y
    public double LPnpY_Wait;
    #endregion

    #region Loader Picker R
    public double LPnpR_Wait;
    public double LPnpR_0;        //Load picker rotate 0 position
    public double LPnpR_90;      //Load picker rotate 90 position
    #endregion


    #region Stage X
    public double[] dGRD_X_Zero;
    public double[] dGRD_X_Wait;

    //public double[] StagX_DrsStart;
    //public double[] StagX_DrsEnd;
    public double[] StagX_DrsOffset;

    public double[] StagX_TblGrdStart;
    public double[] StagX_TblGrdEnd;
    #endregion

    #region Stage Y
    public double[] dGRD_Y_Wait;
    /// <summary>
    /// 테이블 클리닝 시작 포지션
    /// </summary>
    public double[] dGRD_Y_ClnStart;
    public double[] dGRD_Y_ClnEnd;
    public double[] dGRD_Y_DrsStart;
    public double[] dGRD_Y_DrsEnd;
    public double[] dGRD_Y_DrsChange;
    /// <summary>
    /// 테이블 상단 측정 위치
    /// </summary>
    public double[] dGRD_Y_TblInsp;
    /// <summary>
    /// Table Grinding Start Position
    /// </summary>
    public double[] dGRD_Y_TblGrdSt;
    /// <summary>
    /// Table Grinding End Position
    /// </summary>
    public double[] dGRD_Y_TblGrdEd;
    #endregion

    #region Stage Z
    public double[] dGRD_Z_Wait;
    /// <summary>
    /// 테이블이 움직이기 위한 Z축의 허용 가능 높이
    /// </summary>
    public double[] dGRD_Z_Able;
    /// <summary>
    /// 
    /// </summary>
    public double[] dGRD_Z_Rfid;
    #endregion

    #region Unloader Picker X
    public double dOFP_X_Wait;
    public double dOFP_X_PickL;
    public double dOFP_X_PickR;
    public double dOFP_X_Place;
    public double dOFP_X_Conv; //190321 ksg :
    public double UPnpX_AirClean; // Unload picker air clean X postion
    #endregion

    #region Unloader Picker Z
    public double dOFP_Z_Wait;
    public double dOFP_Z_ClnStart;

#if true //20200424 jhc : Off-Picker Z축 Strip Clean 높이 별도 설정
    //public double dOFP_Z_StripClnStart; //Strip Clean 높이
#endif
    public double UPnpZ_AirClean; // Unload picker air clean Z postion
    #endregion

    #region Unloader Picker Y
    public double UPnpY_Wait;
    #endregion

    #region Unloader Picker R
    public double UPnpR_Wait;
    public double UPnpR_0;        //Unload picker rotate 0 position
    public double UPnpR_90;      //Unload picker rotate 90 position
    #endregion 

    #region Dry X
    public double dDRY_X_Wait;
    /// <summary>
    /// 최종 배출 위치
    /// </summary>
    public double dDRY_X_Out;
    #endregion

    #region Dry Z
    public double dDRY_Z_Wait;
    public double dDRY_Z_Up;
    public double dDRY_Z_Check;
    //220117 HJP 자재 감지 체크
    public double dDRY_Z_CheckLimit;
    //End
    #endregion

    #region Dry R
    public double dDRY_R_Wait;
    #endregion

    #region Off Loader X
    public double dOFL_X_Wait;
    /// <summary>
    /// 240mm 기준 포지션
    /// </summary>
    public double dOFL_X_DefAlign;
    #endregion

    #region Off Loader Y
    public double dOFL_Y_Pick;
    public double dOFL_Y_Place;
    #endregion

    #region Off Loader Z
    public double dOFL_Z_Wait;
    public double dOFL_Z_TPickGo;
    public double dOFL_Z_TClamp;
    public double dOFL_Z_TPickUp;
    public double dOFL_Z_TPlaceGo;
    public double dOFL_Z_TUnClamp;
    public double dOFL_Z_TPlaceDn;
    public double dOFL_Z_BPickGo;
    public double dOFL_Z_BClamp;
    public double dOFL_Z_BPickUp;
    public double dOFL_Z_BPlaceGo;
    public double dOFL_Z_BUnClamp;
    public double dOFL_Z_BPlaceDn;
    #endregion

    #region SW21N
    #region Grd Probe Z
    public double[] dGRD_PRBZ_Wait;
    public double[] dGRD_PRBZ_Able;
    #endregion

    #region Dress Y
    public double[] dGRD_DY_Wait;
    public double[] dGRD_DY_DrsStart;
    public double[] dGRD_DY_DrsEnd;
    public double[] dGRD_DY_DrsChange;
    #endregion
    #endregion SW21N

    public double GetVal(string name)
    {
        return (double)GetType().GetField(name).GetValue(this);
    }

    public double GetVal(string name, int index)
    {
        double[] arr = (double[])GetType().GetField(name).GetValue(this);
        return arr[index];
    }

    public void SetVal(string name, double val)
    {
        object obj2 = this;
        GetType().GetField(name).SetValue(obj2, val);
        this = (tSyP)obj2;
    }

    public void SetVal(string name, double val, int index)
    {
        object obj2 = this;
        double[] arr = (double[])GetType().GetField(name).GetValue(this);
        arr[index] = val;
        GetType().GetField(name).SetValue(obj2, arr);
        this = (tSyP)obj2;
    }
}
#endregion

/// <summary>
/// Option Struct
/// </summary>
public struct tOpt
{
    /// <summary>
    /// Warm Up Time 웜업 시간 [m]
    /// </summary>
    public int iWmUT;
    /// <summary>
    /// Warm Up Spindle Speed 웜업 스핀들 속도 [rpm]
    /// </summary>
    public int iWmUS;
    /// <summary>
    /// Wheel Measure Tip Height Spindle Speed 휠 측정 시 스핀들 속도 [rpm]
    /// </summary>
    public int iMeaS;
    /// <summary>
    /// Wheel Measure Tip Height Delay Time 횔 측정 시 대기 시간 [ms]
    /// </summary>
    public int iMeaT;

    #region L/U Picker
    /// <summary>
    /// Pick 작업 시 워터 클린 높이 [mm]
    /// </summary>
    public double dPickGap;
    /// <summary>
    /// Pick 작업 시 워터 클린 대기 시간 [ms]
    /// </summary>
    public int iPickDelay;
    /// <summary>
    /// Place 작업 시 워터 클린 높이 [mm]
    /// </summary>
    public double dPlaceGap;
    /// <summary>
    /// Place 작업 시 워터 클린 대기 시간 [ms]
    /// </summary>
    public int iPlaceDelay;

    /// <summary>
    /// 온로더 피커 테이블 Place 할때 워터 대기 시간
    /// </summary>
    public int[] aOnpRinseTime;

    /// <summary>
    /// 로더 피커 클리너 워터 카운트
    /// </summary>
    public int LPnpCleanerWCnt;
    /// <summary>
    /// 로더 피커 클리너 에어 카운트
    /// </summary>
    public int LPnpCleanerACnt;

    /// <summary>
    /// 스펀지 클린 시 타입 설정 
    /// 좌/우 또는 업/다운
    /// </summary>
    public ESpongeType UpnpSpongeType;
    /// <summary>
    /// Bottom Cleaner Cleaning Picker Base Count
    /// 바텀 클리너에 피커 베이스를 닦는 횟수 [ea]
    /// </summary>
    public int UpnpSpongeCnt;
    /// <summary>
    /// Bottom cleaner up/down 크리닝 시 상승양 [mm]
    /// </summary>
    public double UpnpSpongeUpDistance;

    /// <summary>
    /// 언로더 피커 클리너 워터 카운트
    /// </summary>
    public int UPnpCleanerWCnt;
    /// <summary>
    /// 언로더 피커 클리너 에어 카운트
    /// </summary>
    public int UPnpCleanerACnt;
    /// <summary>
    /// 언로더 피커 IV Vision 사용 유무
    /// </summary>
    public bool UPnpVisionUse; //220210 HJP IV 옵션 추가


    #endregion

    /// <summary>
    /// Table Grinding Step Parameter Array
    /// </summary>
    public tStep[] aTbGrd;
    /// <summary>
    /// Last Left Table Grinding Time
    /// </summary>
    public DateTime dtLast_L;
    /// <summary>
    /// Last Right Table Grinding Time
    /// </summary>
    public DateTime dtLast_R;
    /// <summary>
    /// Magazine Empty Count
    /// 연속 Magazin Empty Slot Push 할때 Mgz 자동 배출 
    /// </summary>
    public int iEmptySlotCnt;
    /// <summary>
    /// Wheel 측정 시 TTV 제한 값 [mm]
    /// </summary>
    //public double dWhlTTV;
    public double[] aWhlTTV;

    /// <summary>
    /// 
    /// </summary>
    public int iChangeLevel; //190509 ksg :
    /// <summary>
    /// Loader/UnLoader Light Curtain 감지 제한 시간
    /// </summary>
    public int iPasueLimittime; // 210722 htg
    /// <summary>
    /// Table Skip false:Use, true:Skip 
    /// </summary>
    public bool[] aTblSkip;
    /// <summary>
    /// Door Skip false:Use, true:Skip 
    /// </summary>
    public bool bDoorSkip;
    /// <summary>
    /// Light curtain Skip false:Use, true:Skip 
    /// </summary>
    public bool bLightcurtainSkip;
    /// <summary>
    /// Buzzer Skip false:Use, true:Skip 
    /// </summary>
    public bool bBuzzerSkip;
    /// <summary>
    /// Room lamp Skip false:Use, true:Skip 
    /// </summary>
    public bool bRoomLampSkip;
    /// <summary>
    /// Cover Skip false:Use, true:Skip 
    /// </summary>
    public bool bCoverSkip;
    /// <summary>
    /// Grind Skip false:Use, true:Skip (Dry Auto Run Mode) 
    /// </summary>
    public bool bDryAuto;

    //20190628 ghk_automeasure
    /// <summary>
    /// Measure Strip When Skip Grinding  false:Use, true:Skip (Dry Auto Run Mode)
    /// </summary>
    public bool bDryAutoMeaStripSkip;
    //

    /// <summary>
    /// 지정된 유휴시간 이후 자동으로 Pump를 Off 시켜준다.
    /// </summary>
    public int iAutoPumpOff;

    /// <summary>
    /// On Loader Mgz First 작업 위치 선택
    /// On  : Top Slot부터 작업진행
    /// off : Bottom Slot부터 작업진행
    /// </summary>
    public bool bFirstTopSlot; //190503 ksg : 추가

    /// <summary>
    /// Off Loader Mgz First 작업 위치 선택
    /// On  : Top Slot부터 작업진행
    /// off : Bottom Slot부터 작업진행
    /// </summary>
    public bool bFirstTopSlotOff; //190511 ksg : OFF Loader 따로 생성

    /// <summary>
    /// QCVision Test / ByPass Test : 0, ByPass : 1
    /// </summary>
    public bool bQcByPass; //190406 ksg : Qc 추가
    //211124 HJP DF St
    public bool bDFNetUse;
    //End
    //211124 HJP Network drive 설정 
    public bool bNetUse;
    public string sNetIP;
    public string sNetPath;
    public string sNetID;
    public string sNetPw;
    //End
    /// <summary>
    /// Table Manual Pos Setting
    /// </summary>
    //191203 ksg :
    public double LeftTopPos;
    public double LeftBtmPos;
    public double RightTopPos;
    public double RightBtmPos;
    public double LeftXPos;
    public double RightXPos;

    /// <summary>
    /// 2매거진이 Full Slot이 아니고 2개 매거진 자재를 합쳐도 1개 매거진이 full Slot이 아닐경우
    /// On  : 투입 매거진과 동일하게 배출 매거진 발생
    /// off : 배출 매거진이 full Slot 또는 자재가 없을시 배출 
    /// </summary>
    public bool bOfLMgzMatchingOn; //190213 ksg : 추가

    /// <summary>
    /// Dry Safety Check 동작 시, Strip 유무 감지
    /// On  : 사용
    /// Off : 사용 안함
    /// </summary>
    public bool bCheckStripExist; //220110 HJP 자재 감지 유무

    /// <summary>
    /// MTBA MTBF MTBA 기준 시간(단위 분)
    /// Language 선택
    /// </summary>
    public ELang eSelLan;

    //191125 ksg :
    /// <summary>
    /// SECS / GEM USE
    /// </summary>
    public bool bSecsUse;

    /// <summary>
    /// Log In / Out Operator ID USE
    /// </summary>
    public bool bOperatorId;

    // 200728 jym : 휠 클린 노즐 추가
    /// <summary>
    /// 휠 클린 노즐 사용 skip 유무
    /// </summary>
    public bool bWhlClnSkip;

    // syc : Warm up 유휴 시간
    /// <summary>
    /// 웜업 유휴시간 설정
    /// </summary>
    public int iWmUI;

    //201005 pjh : Log Delete Period
    /// <summary>
    /// Log 자동 삭제 주기
    /// </summary>
    public int iDelPeriod;

    /// <summary>
    /// Meca Measure 시 이전 측정값과의 차이 발생 허용 범위
    /// 초과 시 Error 발생
    /// </summary>
    public double dMeaTsDiffRange;
    public double dMeaTblDiffRange;
    public double dMeaDrsDiffRange;

    /// <summary>
    /// Table 2Point Measure 시 위, 아래 측정값과의 차이 발생 허용 범위
    /// 초과 시 Error 발생
    /// </summary>
    public double dMeaTblTopBtmDiffRange;


    //210422 HJP
    /// <summary>
    /// 테이블 그라인딩 프로브로 툴세터 측정 여부
    /// </summary>
    public bool bTbgBf_MeaP2TS;
    public bool bTbgBf_MeaWhl;
    public bool bTbgBf_MeaTbl;
    public bool bTbgAf_MeaWhl;
    public bool bTbgAf_MeaTbl;

    public bool bStart_MeaRfid;
    public bool bStart_MeaP2TS;
    public bool bStart_MeaWhl;
    public bool bStart_MeaDrs;
    public bool bStart_MeaTbl;

    public bool bDrsBf_MeaP2TS;
    public bool bDrsBf_MeaWhl;
    public bool bDrsBf_MeaDrs;
    public bool bDrsAf_MeaWhl;
    public bool bDrsAf_MeaDrs;

    public bool bStrGrdBf_MeaP2TS;
    public bool bStrGrdBf_MeaWhl;
    public bool bStrGrdBf_MeaTbl;
    public bool bStrGrdBf_MeaStr;
    public bool bStrGrdAf_MeaStr;

    public bool bStart_MeaTblIPG;
    public bool bStrGrdBf_MeaStrIPG;
    public bool bStrGrdAf_MeaStrIPG;

    /// <summary>
    /// 신규 휠에 대해 1포인트 측정만 할것인가? 
    /// true:1 포인트  false:3 포인트
    /// </summary>
    public bool isMeaNewWhl_1Pt;
    /// <summary>
    /// 사용중인 휠에 대해 1포인트 측정만 할것인가? 
    /// true:1 포인트  false:3 포인트
    /// </summary>
    public bool isMeaUseWhl_1Pt;

    /// <summary>
    /// 신규 드레셔에 대해 1포인트 측정만 할것인가? 
    /// true:1 포인트  false:5 포인트
    /// </summary>
    public bool isMeaNewDrs_1Pt;
    /// <summary>
    /// 사용중인 드레셔에 대해 1포인트 측정만 할것인가? 
    /// true:1 포인트  false:5 포인트
    /// </summary>
    public bool isMeaUseDrs_1Pt;

    /// <summary>
    /// 처음 테이블 측정 시 몇번 측정 할 것인가? 
    /// true:1 회  false:2 회
    /// </summary>
    public bool isMeaTblStart_1Time;
    /// <summary>
    /// 러닝 도중 테이블 측정 시 몇번 측정 할 것인가? 
    /// true:1 회  false:2 회
    /// </summary>
    public bool isMeaTblRun_1Time;

    /// <summary>
    /// Table 측정 포인트
    /// 0 : 1point, 1 : 2point, 2 : 4point
    /// </summary>
    public int iMeaUseTbl_Pt;

    public bool bStrMea_MeaTblRef_BfGrd;
    public bool bStrMea_MeaTblRef_Run;
    public bool bIdleTime;                  //TRUE = 한다. / FALSE = 안한다.

    public int iIdleTime;
    public int iAutoWarmUpTime;
    //

    /// <summary>
    /// Laser -> Strip 측정 방식
    /// Window (0) : 스트립 윈도 영역 단위별 측정 후 -> 스트립 윈도 단위 측정 결과 도출
    /// Chip   (1) : 스트립 전체 영역을 한번에 측정 후 -> 개별 칩 단위 측정 결과 도출
    /// </summary>
    public ELsrStripMeaType LaserMeaStripType;
    /// <summary>
    /// Laser -> Strip chip 단위 측정 시 후보정 방법
    /// None   (0) : 후보정 없음
    /// Window (1) : 스트립 윈도 단위 연산값 기준 보정
    /// Strip  (2) : 스트립 전체 연산값 기준 보정
    /// </summary>
    public ELsrAfCalType LaserMeaStripAfterCalibration;
    /// <summary>
    /// Laser -> Strip chip 단위 측정 시 후보정 적용시 보정 기준값
    /// 개별 chip 측정/연산값이 보정 기준값 범위 벗어날 경우 인접 chip 측정/연산값으로 대체 적용
    /// LaserMeaStripAfterCalibration = ELsrAfCalType.Strip 인 경우 이 값의 2배수가 최종 측정 TTV로 귀결되는 효과가 있음
    /// </summary>
    public double dLaserMeaStripAfCalLimit;

    // 220303 : Laser 측정 파라미터
    public double dLaserMeaDist_TS;     // = 1.0;  // Scan[by seq.]
    public double dLaserMovDist_TS;     // = 7.0;  // Scan[by seq.]
    public double dLaserMovSpeed_TS;    // = 1.0;  // [mm/s]
    public int iLaserMinDataNum_TS;     // = 2;
    // Laser meca 측정 시 측정값 정합성 확인을 위해 2nd, 3rd 측정 시 이전/이후 측정 값 편차 허용 범위 [mm]
    public double dLaserConsistencyLimit_TS;     // ToolSetter 반복 측정 consistency 검증용 : = 0.005 [mm]
    public double dLaser_ND_Filter_Bin_Range_TS; // Laser Raw 데이터 중 정규분포 샘플링 시 단위 구간의 두께 범위

    //public double dLaserMovDist_DRS;  // = 0.0;  // Spot 측정 (Dresser_R 축만 회전)
    //public double dLaserMeaDist_DRS;  // = 0.0;  // Spot 측정 (Dresser_R 축만 회전)
    public double dLaserMeaRpm_DRS;     // = 60.0; // Dresser_R 축 회전 속도 [rpm]
    public int iLaserMeaTime_DRS;       // = 1000; // Dresser_R 축 회전 중 측정 시간 [ms]
    public int iLaserMinDataNum_DRS;    // = 100;
    // Laser meca 측정 시 측정값 정합성 확인을 위해 2nd, 3rd 측정 시 이전/이후 측정 값 편차 허용 범위[mm]
    public double dLaserConsistencyLimit_DRS;     // Dresser 반복 측정 consistency 검증용 : = 0.005 [mm]
    public double dLaser_ND_Filter_Bin_Range_DRS; // Laser Raw 데이터 중 정규분포 샘플링 시 단위 구간의 두께 범위
    // 220420 : Laser -> Dresser 측정 시 나선형 측정 방식
    public double dLaserMeaSpeed_DRS;   // = 5.0;  // Dresser_Y 축 이동 속도 [mm/s]
    // 220421 : Laser -> Dresser 측정 시 최대값 사용 옵션
    public bool bLaserSelectMaxVal_DRS; // true : Dresser 측정 시 최대값 사용 (LaserManager._data_HighSelect())
    public double dLaser_HighValueDiscardRate_DRS; // = 5; // Dresser 측정 최대값 사용 시 높은 값 버리는 비율 [%] (튀는 데이터)

    public double dLaserMeaDist_TBL;    // = 2.0;  // Scan[by buffer func.]
    public double dLaserMovDist_TBL;    // = 10.0; // Scan[by buffer func.]
    public double dLaserMovSpeed_TBL;   // = 10.0; // [mm/s]
    public int iLaserMinDataNum_TBL;    // = 20; // 50;
    public double dLaser_ND_Filter_Bin_Range_TBL; // Laser Raw 데이터 중 정규분포 샘플링 시 단위 구간의 두께 범위

    /// <summary>
    /// Laser -> Strip 측정 (Window 측정 방식용)
    /// Laser 측정 시 strip window 시작 cell Y축 중심 위치에서 측정 시작/끝 위치 간의 여유 거리
    /// Motion library에서 신호 발생 ~ Laser storage 실제 시작 시간 delay 고려한 거리 마진
    /// Y축 encoder 값을 보고 storage start/stop 신호 발생하더라도 제어기=>Laser 신호 delay (약 20 ms) 고려 필요
    /// 2.0 mm => 측정 시작 셀의 Y축 중심에서 2 mm 지나친 위치에서 storage start 신호 발생
    ///           측정 끝 셀의 Y축 중심에서 2mm 전 위치에서 storage stop 신호 발생
    /// </summary>
    public double dLaserMeaDist_STRW;   // 미사용 // Scan[by motion library]
    public double dLaserMovDist_STRW;   // Window 첫/마지막 칩 중심에서 설정 거리만큼 전/후 이동 = 50.0; // Scan[by motion library]
    public double dLaserMovSpeed_STRW;  // = 50.0; // [mm/s]
    public int iLaserMinDataNum_STRW;   // = 100;

    /// <summary>
    /// Laser -> Strip 측정 (Cell 측정 방식용)
    /// Strip Ref. ~ Strip 마지막 Cell 까지의 등속 측정을 위해 전/후 이동 구간 마진 필요 
    /// Strip Ref. 측정 구간 : 5 mm => 측정 이동 속도 50 mm/s, 샘플링 주기 1 ms => 100 개 데이터 획득
    /// </summary>
    public double dLaserMeaDist_STRC_Ref;   // Strip Ref. 측정 거리 = 5.0;  // Scan[by motion library]
    public double dLaserMovDist_STRC;       // Strip Ref. 전, Strip 마지막 chip 중심 후 이동 거리 = 50.0; // Scan[by motion library]
    public double dLaserMovSpeed_STRC;      // = 50.0; // [mm/s]
    public int iLaserMinDataNum_STRC;       // = 40; // 50;

    public double dLaser_ND_Filter_Bin_Range_STRIP; // Laser Raw 데이터 중 정규분포 샘플링 시 단위 구간의 두께 범위

    /// <summary>
    /// Laser 측정 후 획득한 데이터 사전 필터링(High/Low 각각) 데이터 비율 [%]
    /// 불특정 튀는 데이터를 연산에서 제외하기 위한 용도
    /// </summary>
    public int iLaserMeaData_PreFilterRate; // = 20;

    /// <summary>
    /// IPG 측정 위치의 strip column 중심 X축 위치에서 Laser 측정 시 비켜서 측정할 거리 [mm]
    /// IPG 측정 위치(X축)를 Laser 측정 회피 용
    /// </summary>
    public double dLaserIPGSeparateOffset;

    // 220322 : Target mode laser->strip 측정
    public double dLaserMeaTarget_STRC_Stag1; // Manual Laser->Strip 측정 : Target Mode 측정시 target 두께 (Stage #1)
    public double dLaserMeaTarget_STRC_Stag2; // Manual Laser->Strip 측정 : Target Mode 측정시 target 두께 (Stage #2)
    public double dLaserMeaTarMinLimit_STRC; // Laser->Strip 측정 raw 데이터 중 target 두께 기준 lower 데이터 취득 한계값
    public double dLaserMeaTarMaxLimit_STRC; // Laser->Strip 측정 raw 데이터 중 target 두께 기준 upper 데이터 취득 한계값
    public int iLaserMeaTarMinDataNum_STRC;  // Laser->Strip 측정 raw 데이터 중 target 두께 기준 범위 내의 데이터 취득 시 최소 유효데이터 인정 수량
    //....

    // 220330 : Laser 측정 raw data 정규 분포 필터링
    public bool bLaser_NormDist_Filter_Use;                 // Laser Raw 데이터 중 정규분포 샘플링 사용 여부
    public double dLaser_NormDist_Filter_SectionThickness;  // Laser Raw 데이터 중 정규분포 샘플링 시 단위 구간의 두께 범위
    //....

    // 220331 : Laser scan chip 단위 측정 -> 한 column 내 측정 데이터 TTV 범위 초과 시 재측정
    public int iLaserMeaStripColumnRetryMax;    // Laser->Strip_Column 최대 재측정 횟수 (0: 측정 후 retry 없음)
    public double dLaserMeaStripColumnTTVLimit; // Laser->Strip_Column 측정시 TTV 허용 범위 (초과시 재측정)
    //....

    // 210506 jhc : SW21 신규추가
    /// <summary>
    /// 휠 측정 후 첫 스트립 그라인딩의 첫 스텝에서 Z축 end position offset
    /// [0]: Stage1, [1]: Stage2
    /// </summary>
    public double[] dWheelMeasureInDepth;
    /// <summary>
    /// 드레싱 후 첫 스트립 그라인딩의 첫 스텝에서 Z축 end position offset
    /// [0]: Stage1, [1]: Stage2
    /// </summary>
    public double[] dDressingInDepth;
    //

    // 210811 : 스트립 그라인딩 시작 Z축 위치 결정 방법
    public eStripGrindCorrectMode eSGCorrectMode;
    //

    /// <summary>
    /// 휠 마모 보정 => 그라인딩 Z축 시작/종료 위치 계산에 반영 로직 적용 여부
    /// </summary>
    public bool bWheelLossCorrectionUse;

    // 2021.05.17 jhLee : 연속LOT (Multi-LOT) 기능 사용 여부, CDataOption.UseMultiLOT 이 활성화 된 상태에서 사용 가능
    /// <summary>
    /// 연속 LOT 기능 사용  false:사용안함, true:사용 함
    /// </summary>
    public bool bMultiLOTUse;

    /// <summary>
    /// 연속 LOT에서 LOT의 구분을 위한 연속된 빈 Slot의 수량 3 ~ 5
    /// </summary>
    public int nLOTEndEmptySlot;


    // SMEC SG1000U 전용 옵션

    /// <summary>
    /// Mgz lock을 사용하는지 여부
    /// false로 지정하면 원점 찾기 및 Mgz Lock에 관련된 기능을 Skip한다. 센서 검사는 진행한다.
    /// </summary>
    public bool bMgzLockUse;

    /// <summary>
    /// AGV를 사용하는 모드인가 ?
    /// </summary>
    public bool bAGVUse;

    /// <summary>
    /// 특정 Rail 미사용 설정, 최소한 1개 이상은 사용되어야 한다. 
    /// </summary>
    public bool bRailSkip1;             // 1번 Rail 미사용
    public bool bRailSkip2;             // 2번 Rail 미사용
    public bool bRailSkip3;             // 3번 Rail 미사용


    /// <summary>
    /// Auto 상태가 되면 자동으로 Lock을 잠그어 줄 것인가 ?
    /// </summary>
    public bool bAutoDoorLockSkip;          // Auto 상태가 되면 자동으로 Lock을 잠그어 줄 것인가 ?

    /// <summary>
    /// Ionizer를 자동으로 켜주는것을 Skip 할 것인가 ?
    /// </summary>
    public bool bIonizerAutoSkip;           // Ionizer를 자동으로 켜줄것인가 ?

    /// <summary>
    /// 드레셔 측정시 프로브 정합성 검사 범위에 기준값을 추가하는 값 [mm]  기준값(0.005mm) + 값
    /// Dressor 측정 Range Option, 기준값(0.005mm)에 추가로 더하여 기준값을 증가 혹은 감소 시킴, Master Level에서만 변경 가능, SMEC SG1000U에서만 사용
    /// </summary>
    public double dbDRESSER_PROBE_RANGE_ADD;


    //20190309 ghk_level
    #region Auto
    /// <summary>
    /// Auto - Manual
    /// </summary>
    public ELv iLvManual;

    /// <summary>
    /// Auto - Device
    /// 메인화면 우측 상단 Device Name 클릭 포함
    /// </summary>
    public int iLvDevice;

    /// <summary>
    /// Auto - Wheel
    /// </summary>
    public int iLvWheel;

    /// <summary>
    /// Auto - Spc
    /// </summary>
    public int iLvSpc;

    /// <summary>
    /// Auto - Option
    /// </summary>
    public int iLvOption;

    /// <summary>
    /// Auto - Util
    /// </summary>
    public int iLvUtil;

    /// <summary>
    /// Auto - Exit
    /// </summary>
    public int iLvExit;
    #endregion

    #region Manual
    /// <summary>
    /// Manual - 매뉴얼
    /// </summary>
    public int iLvWarmSet;

    /// <summary>
    /// Manual - 온로더
    /// </summary>
    public int iLvOnL;

    /// <summary>
    /// Manual - 인레일
    /// </summary>
    public int iLvInr;

    /// <summary>
    /// Manual - 온로더 피커
    /// </summary>
    public int iLvOnp;

    /// <summary>
    /// Manual - 그라인드 왼쪽
    /// </summary>
    public int iLvGrL;

    /// <summary>
    /// Manual - 그라인드 양쪽
    /// </summary>
    public int iLvGrd;

    /// <summary>
    /// Manual - 그라인드 오른쪽
    /// </summary>
    public int iLvGrr;

    /// <summary>
    /// Manual - 오프로더 피커
    /// </summary>
    public int iLvOfp;

    /// <summary>
    /// Manual - 드라이
    /// </summary>
    public int iLvDry;

    /// <summary>
    /// Manual - 오프로더
    /// </summary>
    public int iLvOfL;

    //20191204 ghk_level
    /// <summary>
    /// Manual - 올 서버 온 버튼 활성/비활성
    /// </summary>
    public int iLvAllSvOn;
    /// <summary>
    /// Manual - 올 서버 오프 버튼 활성/비활성
    /// </summary>
    public int iLvAllSvOff;
    //
    #endregion

    #region Device
    /// <summary>
    /// Device - 그룹 생성
    /// </summary>
    public int iLvGpNew;
    /// <summary>
    /// Device - 그룹 복사 붙이기
    /// </summary>
    public int iLvGpSaveAs;
    /// <summary>
    /// Device - 그룹 삭제
    /// </summary>
    public int iLvGpDel;
    /// <summary>
    /// Device - 디바이스 생성
    /// </summary>
    public int iLvDvNew;
    /// <summary>
    /// Device - 디바이스 복사 붙이기
    /// </summary>
    public int iLvDvSaveAs;
    /// <summary>
    /// Device - 디바이스 삭제
    /// </summary>
    public int iLvDvDel;
    /// <summary>
    /// Device - 디바이스 불러와서 적용하기
    /// </summary>
    public int iLvDvLoad;
    /// <summary>
    /// Device - 디바이스 현재 파라미터 보기
    /// </summary>
    public int iLvDvCurrent;
    /// <summary>
    /// Device - 디바이스 저장(수정)
    /// </summary>
    public int iLvDvSave;
    //20191203 ghk_level
    /// <summary>
    /// Device - 디바이스 파라미터 설정 기능
    /// </summary>
    public int iLvDvParaEnable;
    /// <summary>
    /// Device - 디바이스 Set Position 숨기기
    /// </summary>
    public int iLvDvPosView;
    #endregion

    #region Wheel
    /// <summary>
    /// Wheel - 휠 생성
    /// </summary>
    public int iLvWhlNew;
    /// <summary>
    /// Wheel - 휠 복사 붙이기
    /// </summary>
    public int iLvWhlSaveAs;
    /// <summary>
    /// Wheel - 휠 삭제
    /// </summary>
    public int iLvWhlDel;
    /// <summary>
    /// 휠 저장 / 적용
    /// </summary>
    public int iLvWhlSave;
    /// <summary>
    /// 휠 저장 / 적용
    /// </summary>
    public int iLvWhlChange;
    /// <summary>
    /// 휠 저장 / 적용
    /// </summary>
    public int iLvWhlDrsChange;
    #endregion

    #region Spc
    /// <summary>
    /// Spc - 그래프 저장
    /// </summary>
    public int iLvSpcGpSave;
    /// <summary>
    /// Spc - 에러 리스트 창
    /// </summary>
    public int iLvSpcErrList;
    /// <summary>
    /// Spc - 에러 히스토리 창
    /// </summary>
    public int iLvSpcErrHis;
    /// <summary>
    /// Spc - 에러 히스토리 뷰 버튼
    /// </summary>
    public int iLvSpcErrHisView;
    /// <summary>
    /// Spc - 에러 히스토리 저장
    /// </summary>
    public int iLvSpcErrHisSave;
    #endregion

    #region Option
    /// <summary>
    /// Option - 시스템 포지션
    /// </summary>
    public int iLvOptSysPos;
    /// <summary>
    /// Option - 테이블 그라인딩
    /// </summary>
    public int iLvOptTbGrd;

    // 2020.10.09 SungTae Start : Add only Qorvo
    /// <summary>
    /// Option - On/Off Loader
    /// </summary>
    public int iLvOptLoader;
    /// <summary>
    /// Option - Inrail / Dry
    /// </summary>
    public int iLvOptRailDry;
    /// <summary>
    /// Option - On/Off Picker
    /// </summary>
    public int iLvOptPicker;
    /// <summary>
    /// Option - Left/Right Grind
    /// </summary>
    public int iLvOptGrind;
    // 2020.10.09 SungTae End
    #endregion

    #region Util
    /// <summary>
    /// Util - 모션
    /// </summary>
    public int iLvUtilMot;
    /// <summary>
    /// Util - 스핀들
    /// </summary>
    public int iLvUtilSpd;
    /// <summary>
    /// Util - 인풋
    /// </summary>
    public int iLvUtilIn;
    public int iLvUtilOut;
    /// <summary>
    /// Util - 아웃풋
    /// </summary>
    public int iLvUtilPrb;
    /// <summary>
    /// Util - 타워램프
    /// </summary>
    public int iLvUtilTw;
    /// <summary>
    /// Util - 바코드
    /// </summary>
    public int iLvUtilBcr;
    /// <summary>
    /// Util - 반복 측정
    /// </summary>
    public int iLvUtilRepeat;
    #endregion

    #region OpManual
    //20191204 ghk_level
    public int iLvOpDrsPos;

    // 2020-10-21, jhLee : Skyworks VOC, 작업자 레벨에 따라 Magazine의 Strip 존재여부 편집 기능을 사용 권한을 지정한다.
    /// <summary>
    /// OPManual - 서브화면의 Magazine의 Strip 존재여부 편집 권한 지정
    /// </summary>
    public int iLvOpStripExistEdit;

    #endregion
    //

    /// <summary>
    /// 테이블 클리닝 Water 이동 속도 0:왼쪽 1:오른쪽
    /// </summary>
    public double[] aTC_WaterVel;
    /// <summary>
    /// 테이블 클리닝 Water 카운트 0:왼쪽 1:오른쪽
    /// </summary>
    public int[] aTC_WaterCnt;

    /// <summary>
    /// 테이블 클리닝 Air 이동 속도 0:왼쪽 1:오른쪽
    /// </summary>
    public double[] aTC_AirVel;
    /// <summary>
    /// 테이블 클리닝 Air 카운트 0:왼쪽 1:오른쪽
    /// </summary>
    public int[] aTC_AirCnt;

    /// <summary>
    /// Short dressing 중 테이블 클리닝(Table Water On) 시간 [ms]
    /// 0:왼쪽 1:오른쪽
    /// </summary>
    public int[] aTC_Short_Tm;

    //20200513 jym : 
    /// <summary>
    /// 매거진 배출 위치 설정
    /// Top/Bottom
    /// </summary>
    public EMgzWay eEmitMgz;

    public ELv[] lvtemp;

    public Type GetType(string name)
    {
        return GetType().GetField(name).FieldType;
    }

    public object GetVal(string name)
    {
        return GetType().GetField(name).GetValue(this);
    }

    public object GetVal(string name, int index)
    {
        IList arr = (IList)GetType().GetField(name).GetValue(this);
        return arr[index];
    }

    public void SetVal(string name, object val)
    {
        object obj = this;
        GetType().GetField(name).SetValue(obj, val);
        this = (tOpt)obj;
    }

    public void SetVal(string name, object val, int index)
    {
        object obj = this;
        IList arr = (IList)GetType().GetField(name).GetValue(obj);
        arr[index] = val;
        GetType().GetField(name).SetValue(obj, arr);
        this = (tOpt)obj;
    }


    // SMEC SG1000U type 한정,

    // 지정 순번의 Rail이 비사용 설정인지여부
    public bool IsRailSkip(int nIdx)
    {
        if ((nIdx >= 0) && (nIdx < 3))
        {
            switch (nIdx)
            {
                // 지정 순번에 맞는 Rail Skip 여부를 회신한다.
                case 0: return bRailSkip1;
                case 1: return bRailSkip2;
                case 2: return bRailSkip3;
            }
        }

        return false;           // Index 지정이 오류라면 무조건 false로 회신
    }

}

public struct tMainLog
{
    /// <summary>
    /// 로그의 시퀀스
    /// </summary>
    public eLog ESeq;
    /// <summary>
    /// 로그 종류
    /// </summary>
    public eLog eType;
    /// <summary>
    /// 로그 발생 시간
    /// </summary>
    public DateTime dtTime;
    /// <summary>
    /// 로그 메세지
    /// </summary>
    public string sMsg;
}

/// <summary>
/// RS-232 정보 
/// </summary>
public struct t232C
{
    /// <summary>
    /// COM 포트 이름
    /// </summary>
    public string sPort;
    /// <summary>
    /// Baud rate 속도
    /// </summary>
    public int iBaud;
    /// <summary>
    /// Data bits
    /// </summary>
    public int iDtBits;
    /// <summary>
    /// Parity
    /// </summary>
    public Parity eParity;
    /// <summary>
    /// Stop bits
    /// </summary>
    public StopBits eStBits;
    /// <summary>
    /// Use RTS
    /// </summary>
    public bool bRts;
    /// <summary>
    /// 
    /// </summary>
    public double dX;
    public double dY;
}

public struct tTowerInfo
{
    public ELamp Red;
    public ELamp Yel;
    public ELamp Grn;
    public EBuzz Buzz;
}
#region //211124 HJP DF 용 구조체 St
/// <summary>
/// 각 파트별 데이터 구조체
/// </summary>
public struct TPart
{
    /// <summary>
    /// Sequence State
    /// 시퀀스 상태
    /// </summary>
    public ESeq iStat;
    /// <summary>
    /// LOT Name
    /// </summary>
    public string sLotName;
    /// <summary>
    /// Magazine Number
    /// </summary>
    public int iMGZ_No;
    /// <summary>
    /// Magazine ID(RFID)
    /// </summary>
    public string sMGZ_ID;
    /// <summary>
    /// Slot Number
    /// </summary>
    public int iSlot_No;
    /// <summary>
    /// 랏 오픈 시 초기화 되어야 함
    /// </summary>
    public int[] iSlot_info;
    /// <summary>
    /// 바코드 입력 값 (U:캐리어 바코드 값)
    /// </summary>
    public string sBcr;

    //20190604 ghk_onpbcr
    /// <summary>
    /// 바코드 검사 유무
    /// </summary>
    public bool bBcr;
    /// <summary>
    /// 오리엔테이션 검사 유무
    /// </summary>
    public bool bOri;

    /// <summary>
    /// Each Module Strip Check 
    /// 각 모듈별 자재 유무 확인 변수
    /// </summary>
    public bool bExistStrip;

    //20191120 ghk_display_strip
    /// <summary>
    /// 센서와 시퀀스상 자재 유무 확인 변수
    /// true : 다름, false : 같음
    /// true 일 경우 자재 상태 점멸 표시 및 에러.
    /// false 일 경우 자재 유무에 따라 자재 표시
    /// </summary>
    public bool bNotMatch;

    public double[] dPcb;
    public double dPcbMax;
    public double dPcbMean;
    public double dPcbMin;
    public double dShiftT; //190529 ksg :

    //20190618 ghk_dfserver
    public double dDfMin;
    public double dDfMax;
    public double dDfAvg;
    public string sBcrUse;

    // 2021.07.30 lhs Start : SECS/GEM에서 받은 Top Mold, Btm Mold 저장용 (UseNewSckGrdProc 적용시)
    public double dTopMoldMax; // 필요할까?
    public double dTopMoldAvg;
    public double dBtmMoldMax;
    public double dBtmMoldAvg;
    // 2021.07.30 lhs End

    public int iTPort;          //20190624 josh    table port 1 : left, 2 : right

    // 200314 mjy : 유닛 데이터 배열 추가
    /// <summary>
    /// 유닛 유무 배열
    /// </summary>
    public bool[] aUnitEx;

    //200624 pjh : Grinding 중 Error Check 변수
    /// <summary>
    /// 자재가 Grinding 중 Error가 발생했는지 Check하는 bool변수
    /// </summary>
    public bool bChkGrd;

    //200712 jhc : 18 포인트 측정 (ASE-KR VOC)
    /// <summary>
    /// 별도 측정 포인트가 지정된 스트립인지 여부 (Lot Open 후 첫 n장)
    /// Before Measure 시작 기준 → On-Picker까지에서는 이 값이 false, L-Table/R-Table 선착하여 Before Measure 시작되는 첫 n장까지 true로 설정됨
    /// Step Mode에서 L-Table에서 첫 n장으로 설정되면 R-Table에서도 첫 n장으로 설정되어야 함
    /// (즉, Step Mode에서 L-Table에서 설정된 bLeaderStrip 값은 L-Table -> Off-Picker -> R-Table로 그 데이터가 shift되어야 함)
    /// </summary>
    public bool b18PMeasure;
    //

    // 2020.12.12 JSKim St
    /// <summary>
    /// AutoRun 진행 간 마지막 iStat를 보관
    /// </summary>
    public int iStripStat;
    // 2020.12.12 JSKim Ed

    // 20201217 myk : Table Vacuum 값 로그 저장
    /// <summary>
    /// Table Vacuum 값 로그 저장 변수
    /// </summary>
    public double dChuck_Vacuum;

    // 2021-05-10, jhLee : Multi-LOT의 표시 
    // 미사용 public bool bIsLotEnd;      // 지정 LOT의 마지막 Strip인가 ?
    public int nLotType;        // Type지정 (색상)
    public bool bIsUpdate;      // Strip의 위치가 변경되었는가 ? 사용되는 LOT Info를 갱신하기 위한 Flag
    public Color LotColor;              // LOT의 색 지정
    public int nLoadMgzSN;       // Load된 Magazine의 Serial 번호

    // 2021.05.31. SungTae Start : [추가]
    public string sDeviceName;
    public string sStage;
    public string sDualMode;
    public string sGrdMode;
    public string sSaveDate;

    public double dBfMin;
    public double dBfMax;
    public double dBfAvg;

    public double dAfMin;
    public double dAfMax;
    public double dAfAvg;

    public double dAfTotMin;
    public double dAfTotMax;
    public double dAfTotAvg;
}
public struct tPbResult
{
    /// <summary>
    /// Probe Before 측정 값
    /// </summary>
    public double dBMax;
    /// <summary>
    /// Probe Before 측정 값
    /// </summary>
    public double dBMin;
    /// <summary>
    /// Probe Before 측정 값
    /// </summary>
    public double dBAvg;
    /// <summary>
    /// Probe Before 측정 값
    /// </summary>
    public double dBMean;
    /// <summary>
    /// Probe After 측정 값
    /// </summary>
    public double dAMax;
    /// <summary>
    /// Probe After 측정 값
    /// </summary>
    public double dAMin;
    /// <summary>
    /// Probe After 측정 값
    /// </summary>
    public double dAAvg;
    /// <summary>
    /// Probe After 측정 값
    /// </summary>
    public double dAMean;
}
//211124 HJP End
#endregion
public struct TGrdData
{
    /// <summary>
    /// 현재 진행 중인 스텝의 인덱스
    /// </summary>
    public int iStep;
    /// <summary>
    /// 리그라인딩 인지 확인
    /// </summary>
    public bool bReGrd;
    /// <summary>
    /// 각 스텝의 그라인딩 횟수 중 현재 횟수
    /// </summary>
    public int[] aInx;
    /// <summary>
    /// 각 스텝의 그라인딩 횟수
    /// </summary>
    public int[] aCnt;
    /// <summary>
    /// 각 스텝의 타겟 높이 [mm]
    /// </summary>
    public double[] aTar;
    /// <summary>
    /// 각 스텝의 리그라인딩이 진행 된 횟수
    /// </summary>
    public int[] aReNum;
    /// <summary>
    /// 각 스텝의 현재 리그라인딩 횟수 중 현재 횟수
    /// </summary>
    public int[] aReInx;
    /// <summary>
    /// 각 스텝의 현재 리그라인딩 횟수
    /// </summary>
    public int[] aReCnt;
    /// <summary>
    /// 각 스텝의 1포인트 측정 값 [mm]
    /// </summary>
    public double[] a1Pt;
    /// <summary>
    /// 스트립 측정 이전 데이터
    /// </summary>
    public double[,] aMeaBf;
    /// <summary>
    /// 스트립 측정 이후 데이터
    /// </summary>
    public double[,] aMeaAf;
    /// <summary>
    /// 이전 원포인트 이전 값
    /// </summary>
    public double[] aOldOnPont; //191018 ksg :

    /// <summary>
    /// 스핀들 부하량 검사 시작 플레그
    /// </summary>
    public bool bSplLoadFlag;
    /// <summary>
    /// 스핀들 최대 부하량 [%]
    /// </summary>
    public double dSplMaxLoad;
}

public struct TDrsData
{
    /// <summary>
    /// 현재 진행 중인 스텝의 인덱스
    /// </summary>
    public int iStep;
    /// <summary>
    /// 각 스텝의 그라인딩 횟수 중 현재 횟수
    /// </summary>
    public int[] aInx;
    /// <summary>
    /// 각 스텝의 그라인딩 횟수
    /// </summary>
    public int[] aCnt;

    public tStep[] aParm;

    // 201006 jym : 여기로 변수 옮김 (기존 구조체 삭제)
    /// <summary>
    /// 드레싱 실행 여부  true:드레싱 할 시점  false:안함
    /// </summary>
    public bool bDrs;
    /// <summary>
    /// 드레싱 파라메터 판별  true:New parameter  false:Using parameter
    /// </summary>
    public bool bDrsR;
    /// <summary>
    /// 드레싱 파라메터 판별2  true:short parameter  false:Using parameter
    /// </summary>
    public EDrsMode eDrsMode;
}

/// <summary>
/// 프로브 반복 테스트
/// </summary>
public struct tProbeTest
{
    /// <summary>
    /// 베이스 측정 값
    /// </summary>
    public double[] dBase;
    /// <summary>
    /// 센터 측정 값
    /// </summary>
    public double[] dCenter;
    /// <summary>
    /// 게이지 블럭 높이
    /// 센터 - 베이스 값
    /// </summary>
    public double[] dBlock;
}

/// <summary>
/// 200326 mjy : 경과시간 구조체
/// </summary>
public struct TElapse
{
    /// <summary>
    /// 시작 시간
    /// </summary>
    public DateTime dtStr;
    /// <summary>
    /// 종료 시간
    /// </summary>
    public DateTime dtEnd;
    /// <summary>
    /// 경과 시간
    /// </summary>
    public TimeSpan tsEls;
}

//211125 HJP DF St
public struct TNetDrive
{
    /// <summary>
    /// 네트워크 드라이브 저장 경로
    /// </summary>
    public string path;
    /// <summary>
    /// 저장 데이터
    /// </summary>
    public string data;

    public TNetDrive(string _path, string _data)
    {
        path = _path;
        data = _data;
    }
}
//End

// SW21 //////////
public struct TDimension
{
    // 210825 : SW21N Base Setup
    public double dD_TBL_HOLE_2_TBL_CENTER; // Nut : 테이블홀(front) ~ 테이블센터 간격 (mm)
    //........
    public double[] dD_TS_2_TBL_CENTER;   // 툴세터 ~ 테이블센터 간격 (mm)
    public double dD_TS_2_DRS_CENTER;   // 툴세터 ~ 드레서센터 간격 (mm)
    public double dD_TS_2_TBL_HOLE;     // 툴세터 ~ 테이블홀 간격 (mm)
    public double dD_WHEEL_RADIUS;      // 휠/휠베이스 외곽 반경 (mm)
    public double dD_DRESSER_RADIUS;    // 드레서 외곽 반경 (mm)

    /// <summary>
    /// 툴세터에 프로브로 Z축 기준위치 설정 시 프로브 DOWN 상태에서 누르는 값
    /// 즉, 프로브 0.0 위치 기준에서 더 누르는 높이 (Default 3.0 mm)
    /// 단순 입력 후 PRB_ORIGIN.dZ 위치 설정 시 프로브 값이 이 값이 되도록 설정해야 함
    /// </summary>
    public double dH_PRB_ORIGIN_HEIGHT;

    /// <summary>
    /// X축 방향으로 테이블 센터와 드레셔 거리
    /// </summary>
    public double[] Tbl2Drs_X;

    /// <summary>
    /// X축 방향으로 테이블 센터와 툴세터의 거리
    /// </summary>
    public double[] Tbl2Ts_X;

    /// <summary>
    /// 테이블 센터에서부터 테이블 측정 위치 X축 거리 [mm]
    /// </summary>
    public double Tbl2Mea_X;

    /// <summary>
    /// 테이블 센터에서부터 테이블 측정 위치(상단) Y축 거리 [mm]
    /// </summary>
    public double Tbl2Mea_Y;
}

public struct TPosXYZ
{
    public double dX;
    public double dY;
    public double dZ;
}

// Nut(2000NX) 용 stage 추가 축 : 변수명 구분을 위해 정의함
public struct TPosN_RYZ
{
    public double dDR;  // 드레서 R축
    public double dDY;  // 드레서 Y축
    public double dPZ;  // 프로브 Z축
}

// Laser 측정시 이동/측정 범위 설정용
public struct TPos_LaserMeasure
{
    public double dMovStart; // Laser 측정 시 Y축 또는 DY축 이동 시작 위치
    public double dMovStop;  // Laser 측정 시 Y축 또는 DY축 이동 완료 위치
    public double dMeaStart; // Laser 측정 시 Y축 또는 DY축 측정 시작 위치
    public double dMeaStop;  // Laser 측정 시 Y축 또는 DY축 측정 끝 위치
    public double dSpeed;    // Laser 측정 시 Y축 또는 DY축 이동 속도
}

public struct TStripThickness
{
    public double total;    // Total 두께 = (mold 두께) + (pcb 두께)
    public double mold;     // Mold(EMC) 두께
    public double pcb;      // PCB 두께. (단, Bottom side인 경우 top side의 total 두께)
}

public struct TBaseSetup
{
    /// <summary>
    /// 프로브와 툴세터 중심 접점 (Z축 위치 = dH_PRB_ORIGIN_HEIGHT 만큼 눌리는 위치)
    /// Z축 절대 기준 위치
    /// 설비 가동 중 재측정 시 절대 위치 대비 Z축 편차값 활용
    /// X,Y,Z축 수동 이동 후 X,Y,Z축 위치 값 입력
    /// 단, Y축은
    /// 2000X  : 테이블 Y축
    /// 2000NX : 드레서 Y축
    /// </summary>
    public TPosXYZ PRB_ORIGIN;

    // 210820 : SW21N Base Setup
    /// <summary>
    /// Nut : 프로브 -> 테이블 홀(front) 접점 (테이블 Y축) 위치
    /// X,Y,Z축 수동 이동 후 (테이블 Y축) 위치 값 입력
    /// </summary>
    public double dY_PRB_2_TBL_HOLE;

    /// <summary>
    /// Nut : 휠_센터_지그 -> 툴세터 접점 (드레서 Y축) 위치
    /// X,Y,Z축 수동 이동 후 (드레서 Y축) 위치 값 입력
    /// </summary>
    public double dY_WHL_CENTER_2_TS;
    //........

    /// <summary>
    /// 휠 센터 Zig가 테이블 홀의 접점 (테이블 Y축) 위치
    /// X,Y,Z축 수동 이동 후 (테이블 Y축) 위치 값 입력
    /// </summary>
    public double dY_WHL_CENTER_2_TBL_HOLE;

    ////////////////////////////////////////////////////////////////////////
    // Base Z축 기준위치 : 테이블, 드레서, 휠 두께 획득을 위한 기준 Z축 위치 //

    /// <summary>
    /// 프로브로 테이블 베이스 측정(3.0 mm) Z축 위치 입력
    /// 2000X  : 스핀들 Z축
    /// 2000NX : 프로브 Z축
    /// 테이블 두께 확인용
    /// </summary>
    public double dZ_TBL_BASE_ORIGIN;

    /// <summary>
    /// 프로브로 드레셔 베이스 측정(3.0 mm) Z축 위치 입력
    /// 드레셔 두께 측정 위치 설정
    /// 2000X  : 스핀들 Z축
    /// 2000NX : 프로브 Z축
    /// </summary>
    public double dZ_DRS_BASE_ORIGIN;

    /// <summary>
    /// 휠베이스로 툴세터 감지되는 (스핀들 Z축) 위치 입력
    /// 휠팁 측정 시작 위치 설정용 (휠팁 측정 시작 위치 = 이 높이 - 새 휠팁 두께)
    /// 휠팁 두께값 계산 기준
    /// </summary>
    public double dZ_WHL_BASE_ORIGIN;

    // 2000NX : Probe Z축 없이 고정 방식 => 각 기구물 Probe 측정값 필요
    public double dV_PRB_ORIGIN_PRBVAL;         // Tool_Setter(or PIN) 측정한 프로브 값
    public double dV_TBL_BASE_ORIGIN_PRBVAL;    // Table_Base 측정한 프로브 값
    public double dV_DRS_BASE_ORIGIN_PRBVAL;    // Dresser_Base 측정한 프로브 값

    ////////////////////////////////////
    // 이하 상기 입력 완료 시 자동 계산 //

    public double dY_WHL_BASE_2_TS;     // 휠베이스와 툴세터 접점 Y축 위치 (휠베이스 높이 측정 위치)
    public double dY_WHL_TIP_2_TS;      // 휠팁과 툴세터 접점 Y축 위치 (휠팁 두께 측정 위치)
    public double dY_PRB_2_DRS_CENTER;  // 프로브 드레셔 센터 접점 Y축 위치 (드레셔 두께 측정 위치, 드레셔 베이스 측정 위치)

    /// <summary>
    /// 프로브로 Z축 기준위치 재측정 시작 Z축 위치
    /// 이 위치까지 고속 Down 후, dH_PRB_ORIGIN_HEIGHT 값으로 정밀 Z축 위치 재측정 시작함
    /// = PROBE_ZERO_POS.dZ - dH_PRB_ORIGIN_HEIGHT - 1.0(Zoro Offset) - 10.0(안전거리)
    /// </summary>
    public double dZ_PRB_ORG_CHECK_START;

    // 여기까지 자동 계산 //
    ///////////////////////

    /// <summary>
    /// 210812 : 드레싱 후 (휠+드레서) 소모량 offset 처리
    /// 드레싱 시 (휠 소모량 + 드레서 소모량)과 드레싱 target 량 차이값 이용
    /// 
    ///  -2: +100 um 초과(Over-Dressing) => Error 발생,
    ///  -1: -100 um 초과(Under-Dressing) => Error 발생,
    ///   0: (-5 ~ 0)um => 무시 (Offset = 0)
    ///  +1: -(5 ~ 100)um (Under-Dressing) => (+)offset = 차이값
    ///  +2: +(0 ~ 100)um (Over-Dressing) => (-)offset = 차이값
    ///  
    /// true : 상기 offset 적용 조건되면 해당 값으로 offset 자동 설정 => 다음 스트립 그라인딩 시부터 적용
    /// false : 입력된 설정값으로 offset 적용하여 스트립 그라인딩 시 적용
    /// </summary>
    public bool b_DRS_AFTER_AUTO_OFFSET;

    /// <summary>
    /// 스트립 그라인딩 시작위치 조정용 오프셋
    /// + : 설정 값 만큼 Z축 시작위치 down => 종료위치도 down됨
    /// - : 설정 값 만큼 Z축 시작위치 up => 종료위치도 up됨
    /// 
    /// 단, 직전 그라인딩 스텝에서 스트립 두께 측정되지 않은 경우 본 offset 적용하지 않고,
    /// 직전 그라인딩시 Z축 최종 위치 기준에서 air-cut 만큼 up 위치에서 그라인딩 시작
    /// </summary>
    public double dZ_GRD_START_OFFSET;

    // 210818 : 드레싱 후 (휠+드레서) 소모량 offset 처리 (누적용)
    // 드레싱 시 (휠 소모량 + 드레서 소모량)과 드레싱 target 량 차이값 이용
    //   +/- 10 um 미만 => 무시 (Offset = 0)
    //   +/- 10 ~ 20 um => offset = 차이값
    //   +/- 20 um 초과 => Error 발생
    //
    // 참고 1. 이 값은 드레싱 동작에도 반영할 목적으로 사용함
    // 참고 2. 이 값은 StageSequence.dZ_GrdZAxisOffset 값과 달리 매 드레싱 시 이전 값에 누적 적용됨 (2000X Old SW의 dTOOL_SETTER_GAP 과 동일한 의미)
    //
    public double dZ_POST_DRESSING_OFFSET;

    /// <summary>
    /// 툴세터 센터 ~ 툴세터 핀 Y축 간격
    /// 휠 측정 툴세터(눌림) 위치와 프로브로 툴세터 측정 위치 맞춤용 핀과 툴세터 간격
    /// +값 : 툴세터보다 고정핀이 더 front에 위치함
    /// </summary>
    public double dY_TS_2_PIN;
    /// <summary>
    /// 툴세터 센터 ~ 툴세터 핀 X축 간격
    /// 휠 측정 툴세터(눌림) 위치와 프로브로 툴세터 측정 위치 맞춤용 핀과 툴세터 간격
    /// 툴세터:프로브 접점 X축 위치가 0이므로 고정핀:프로브 접점의 X축 값이 됨
    /// </summary>
    public double dX_TS_2_PIN;

    // 210825 Nut : 프로브~IPG 간격 (테이블 Y축)
    /// <summary>
    /// 프로브~IPG 간격 (테이블 Y축)
    /// IPG front, Probe back
    /// </summary>
    public double dY_PRB_2_IPG;

    /// <summary>
    /// Blade Wheel 사용
    /// 프로브와 휠의 센터 사이의 거리를 입력 (설계치수 + @) [mm]
    /// </summary>
    public double Prb2Whl_Distance;

    /// <summary>
    /// 프로브가 테이블 센터에 있는 위치 값 [mm]
    /// </summary>
    public TPosXYZ Prb2Tbl;

    /// <summary>
    /// 프로브가 드레셔 센터에 있는 위치 값 [mm]
    /// </summary>
    public TPosXYZ Prb2Drs;

    /// <summary>
    /// Blade wheel 사용
    /// 휠이 툴세터에 있는 위치 값 [mm]
    /// </summary>
    public TPosXYZ Whl2Ts;

    /// <summary>
    /// Blade wheel 사용
    /// 휠이 드레셔 센터에 있는 위치 값 [mm]
    /// </summary>
    public TPosXYZ Whl2Drs;
}

/// <summary>
/// 1. GUI 에서 IPG Calibration 을 위해 사용 하는 Class
///   사용 1)Gui 에서 설정한 값을 기록 : CVAR.IPG_Cal[_nStage].fInProbe_Zaxis_pos = XXX;
///       ㄴ Data 를 Motion Lib 에 Write
/// 2. Probe 로 측정 후 기준값 확보 후 IPG 값을 Cal 하고자 할때 사용
/// List 의 갯수는 1000개까지 사용 하자. (Motion 에서 될까?)
/// </summary>
public class IPG_Calibration_class
{
    public List<int> fYaxis_pos         = new List<int>();          // IPG 값을 획득한 Yaxis 위치 (mm)
    public List<int> fInProbe_Zaxis_pos = new List<int>();          // Probe 측정 Zaxis 값 (mm)
    public List<int> fInProbe_Value     = new List<int>();          // Probe 입력 값 (mm)
    public List<int> fInIPG_Value       = new List<int>();          // IPG 입력 값 
    public List<int> fSetIPG_Data       = new List<int>();          // IPG 설정 값 (mm)
}

public struct TTotalData
{
    public double Min;
    public double Max;
    public double Avg;
}

public struct TWorkTime
{
    public string Start;
    public string End;
    public string Work;
}

//..


/// <summary>
/// 전체 프로세스의 스트립 관련된 정보를 소유
/// </summary>
public class TProcess
{
    /// <summary>
    /// 프로세스 내에 자재 유무
    /// </summary>
    public bool[] exist = new bool[GV.UNIT_MAX];
    /// <summary>
    /// 랏 이름
    /// </summary>
    public string lot = "";
    /// <summary>
    /// 자재의 아이디 (없으면 load 날짜 + 시간)
    /// </summary>
    public string[] id = new string[GV.UNIT_MAX];

    public string MgzId = "";       // Magazine ID
    public int MgzNo = 0;        // Magazine No  

    //// Unit 형태의 제품을 가공할 경우 사용되는 각 Unit의 자료
    //public CUnitInfo[] Units = new CUnitInfo[GV.UNIT_MAX];         // GV 에서 정의한 최대 Unit 수량을 사용, SG1000U 기준 3개

    public EBCRWork[] BCRState = new EBCRWork[GV.UNIT_MAX];         // 2D Vision (BCR/Orientation) 수행 완료 여부
    public EStageWork[] StageState = new EStageWork[GV.UNIT_MAX];   // Table Stage에서의 작업 상황
    public EDryWork[] DryState = new EDryWork[GV.UNIT_MAX];         // Dry Zone에서의 작업 상황


    //public bool UnitExist(int nIdx=-1)
    //{
    //    // 음수이면 1개라도 제품이 존재하면 true
    //    if (nIdx < 0)
    //    {
    //        for (int i = 0; i < exist.Length; i++)
    //        {
    //            if (exist[i]) return true;
    //        }
    //    }
    //    else if ( nIdx < exist.Length)
    //    {
    //        // 지정한 index의 제품이 존재하는지 여부
    //        return exist[nIdx];
    //    }

    //    return false;           // 존재하지 않는다.
    //}
}




///// <summary>
///// Unit 형태의 제품 처리를 위해 각 Unit의 정보를 담아두는 데이터 class
///// SMEC SG1000U에서 사용
///// </summary>
//public class CUnitInfo
//{
//    public bool bExist;                 // 존재 여부
//    public string sBarcode;             // 제품의 바코드 값
//    public EBCRWork nBCRState;   // 2D Vision (BCR/Orientation) 수행 완료 여부
//    // public EVisionState nVerifyState;   // SECS/GEM Verification 수행 완료 여부

//    //// 아래는 미사용 예정
//    //public string sLotName;             // 해당 Unit의 LOT 이름

//    //public string sLDMgzBarcode;          // 투입된 Magazine Barcode
//    //public int nLDMgzNo;                  // 투입된 Magazine Barcode
//    //public int nLDSlotNo;                 // 투입된 Magazine에서의 Slot 번호 

//    //public string sUDMgzBarcode;          // 배출된 Magazine Barcode
//    //public int nUDMgzNo;                  // 배출된 Magazine Barcode
//    //public int nUDSlotNo;                 // 배출된 Magazine에서의 Slot 번호 

//    // 생성자
//    public CUnitInfo()
//    {
//        Clear();
//    }

//    /// <summary>
//    /// 내용을 초기화 한다.
//    /// </summary>
//    public void Clear()                     // 내용을 초기화 한다.
//    {
//        bExist = false;                 // 존재 여부
//        sBarcode = "";                  // 제품의 바코드 값
//        nBCRState = EBCRWork.None;    // Orientation 수행 완료 여부
        
//        //nBarcode = EVisionState.None;    // Barcode 읽기 완료 여부
//        //nVerify = EVisionState.None;    // SECS/GEM Verification 수행 완료 여부

//        //sLotName = "";             // 해당 Unit의 LOT 이름

//        //sLDMgzBarcode = "";          // 투입된 Magazine Barcode
//        //nLDMgzNo = 0;                  // 투입된 Magazine Barcode
//        //nLDSlotNo = 0;                 // 투입된 Magazine에서의 Slot 번호 

//        //sUDMgzBarcode = "";          // 배출된 Magazine Barcode
//        //nUDMgzNo = 0;                  // 배출된 Magazine Barcode
//        //nUDSlotNo = 0;                 // 배출된 Magazine에서의 Slot 번호 
//    }

//    // 지정된 값을 복사한다.
//    public void Copy(CUnitInfo Src)
//    {
//        bExist = Src.bExist;                 // 존재 여부
//        sBarcode = Src.sBarcode;             // 제품의 바코드 값
//        nBCRState = Src.nBCRState;
        
//        //nBarcode = Src.nBarcode;
//        //nVerify = Src.nVerify;

//        //sLotName = Src.sLotName;             // 해당 Unit의 LOT 이름
//        //sLDMgzBarcode = Src.sLDMgzBarcode;          // 투입된 Magazine Barcode
//        //nLDMgzNo = Src.nLDMgzNo;                  // 투입된 Magazine Barcode
//        //nLDSlotNo = Src.nLDSlotNo;                 // 투입된 Magazine에서의 Slot 번호 
//        //sUDMgzBarcode = Src.sUDMgzBarcode;          // 배출된 Magazine Barcode
//        //nUDMgzNo = Src.nUDMgzNo;                  // 배출된 Magazine Barcode
//        //nUDSlotNo = Src.nUDSlotNo;                 // 배출된 Magazine에서의 Slot 번호 
//    }

//    /// <summary>
//    /// 지정한 객체에서 내용을 이동시킨다. 원본은 Clear
//    /// </summary>
//    /// <param name="Dest"></param>
//    public void MoveFrom(ref CUnitInfo Src)
//    {
//        // 대상체에 내용을 복사해준다.
//        bExist          = Src.bExist;
//        sBarcode        = Src.sBarcode;
//        nBCRState       = Src.nBCRState;

//        // nBarcode        = Src.nBarcode;
//        // nVerify         = Src.nVerify;

//        //sLotName =       Src.sLotName;           
//        //sLDMgzBarcode =  Src.sLDMgzBarcode;      
//        //nLDMgzNo =       Src.nLDMgzNo;              
//        //nLDSlotNo =      Src.nLDSlotNo;             
//        //sUDMgzBarcode =  Src.sUDMgzBarcode;      
//        //nUDMgzNo =       Src.nUDMgzNo;              
//        //nUDSlotNo =      Src.nUDSlotNo;

//        Src.Clear();            // 원본은 Clear 해준다.
//    }

//    /// <summary>
//    /// 지정한 객체로 내용을 이동시킨다. 원본은 Clear
//    /// </summary>
//    /// <param name="Dest"></param>
//    public void MoveTo(ref CUnitInfo Dest)
//    {
//        // 대상체에 내용을 복사해준다.
//        Dest.bExist = bExist;
//        Dest.sBarcode = sBarcode;
//        Dest.nBCRState = nBCRState;

//        // Dest.nBarcode = nBarcode;
//        // Dest.nVerify = nVerify;

//        //Dest.sLotName = sLotName;
//        //Dest.sLDMgzBarcode = sLDMgzBarcode;
//        //Dest.nLDMgzNo = nLDMgzNo;
//        //Dest.nLDSlotNo = nLDSlotNo;
//        //Dest.sUDMgzBarcode = sUDMgzBarcode;
//        //Dest.nUDMgzNo = nUDMgzNo;
//        //Dest.nUDSlotNo = nUDSlotNo;

//        Clear();            // 원본은 Clear 해준다.
//    }

//}

