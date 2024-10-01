using System;
using System.Collections;
using System.Drawing;

/// <summary>
/// 측정 위치 구조체
/// </summary>
public struct tCont
{
    public bool bUse;
    public bool bStep; // 220218 : Step Measure Pos. -> BF/AF 측정 시 필수 측정, Target Accuracy 기준 위치
    public double dX;
    public double dY;
}

/// <summary>
/// 그라인딩 스텝 구조체
/// </summary>
public struct tStep
{
    /// <summary>
    /// 사용 유무
    /// </summary>
    public bool use;//1
    /// <summary>
    /// 에어컷 양 [mm]
    /// </summary>
    public double air;//2
    /// <summary>
    /// 사이클 그라인딩 양 [mm]
    /// </summary>
    public double cycle;//3
    /// <summary>
    /// 블레이드 휠의 X축 이동 피치 양 [mm]
    /// </summary>
    public double pitch;
    /// <summary>
    /// TopDown 모드 일때 = 전체 그라인딩 양 [mm], Target 모드 일때 = 해당 스텝 타켓 값[mm]
    /// </summary>
    public double target;//4
    /// <summary>
    /// 테이블 속도 [mm/s]
    /// </summary>
    public double table;//5
    /// <summary>
    /// 스핀들 속도 [rpm]
    /// </summary>
    public int spindle;//6
    /// <summary>
    /// 그라인딩 시작 방향
    /// </summary>
    public EGrdDir startDir;//8
    /// <summary>
    /// 그라인딩 종료 방향
    /// </summary>
    public EGrdDir endDir;//9
    /// <summary>
    /// 블레이드 휠의 그라인딩 진행 방향
    /// </summary>
    public EGrdXY modeXY;

    public double inDepth;

    public eStepMeasureMode stepMeasureMode;//10

    public double grdTarget;//11

    public double reShift;//12

    public int reCount;//13


    #region SW21N
    /// <summary>
    /// Zaxis Down Speed [mm/s]
    /// </summary>
    public double zdownSpeed; //7
    /// <summary>
    /// IPG Use
    /// </summary>
    public bool ipg_use; //14
    /// <summary>
    /// ipg contact zaxis position
    /// </summary>
    public double ipg_zcontact;//15
    /// <summary>
    /// zaxis down positon limit
    /// </summary>
    public double ipg_zlimit;//16
    /// <summary>
    /// ipg contact yaxis start position
    /// </summary>
    public double ipg_start;//17
    /// <summary>
    /// ipg contact yaxis end position
    /// </summary>
    public double ipg_end;//18
    /// <summary>
    /// ipg data acquisition count
    /// </summary>
    public int ipg_daqcount;//19
    /// <summary>
    /// ipg data acquisition count
    /// </summary>
    public double ipg_daqrange;//20

    /// <summary>
    /// Spindle Load Limit [%]
    /// </summary>
    public double spindleload; //21
    /// <summary>
    /// z축 변위량 - ipg 변위량 > diffGapSplRpm  -> Spindle RPM 조정
    /// </summary>
    public double diffGapSplRpm;//22
    /// <summary>
    /// z축 변위량 - ipg 변위량 > diffGapZspeed -> Z축 다운 속도 조정
    /// </summary>
    public double diffGapZspeed;//23
    /// <summary>
    /// z축 변위량 - ipg 변위량 > diffGapYspeed -> Y축 테이블 이동 속도 조정
    /// </summary>
    public double diffGapYspeed;//24
    /// <summary>
    /// z축 변위량 - ipg 변위량 > diffGapDressing -> 자동 드레싱
    /// </summary>
    public double diffGapDressing;//25
    /// <summary>
    /// z축 변위량 - ipg 변위량 > diffGapError  -> 자동 드레싱
    /// </summary>
    public double diffGapError;

    public int ipg_daqDelay;

    public double ipg_daqSetvel;

    public int Dressor_rpm;
    
    #endregion
}

#region SW21N 미사용 삭제
/*
public struct tNX_Step
{
    /// <summary>
    /// 사용 유무
    /// </summary>
    public bool use; //0
    /// <summary>
    /// 에어컷 양 [mm]
    /// </summary>
    public double air; //1
    /// <summary>
    /// Zaxis Down Speed [mm/s]
    /// </summary>
    public double zdown; //2
    /// <summary>
    /// TopDown 모드 일때 = 전체 그라인딩 양 [mm], Target 모드 일때 = 해당 스텝 타켓 값[mm]
    /// </summary>
    public double target; //3
    /// <summary>
    /// 테이블 속도 [mm/s]
    /// </summary>
    public double table;  //4
    /// <summary>
    /// 스핀들 속도 [rpm]
    /// </summary>
    public int spindle;  //5
    /// <summary>
    /// 스핀들 Load Limit [%]
    /// </summary>
    public double spindleload; //6
    /// <summary>
    /// 그라인딩 시작 방향
    /// </summary>
    public EGrdDir startDir; //7
    /// <summary>
    /// 그라인딩 종료 방향
    /// </summary>
    public EGrdDir endDir; //8

    /// <summary>
    /// IPG Use
    /// </summary>
    public bool ipg_use; //9

    /// <summary>
    /// ipg contact zaxis position
    /// </summary>
    public double ipg_zcontact;//10
    /// <summary>
    /// zaxis down positon limit
    /// </summary>
    public double ipg_zlimit;//11
    /// <summary>
    /// ipg contact yaxis start position
    /// </summary>
    public double ipg_start;//12
    /// <summary>
    /// ipg contact yaxis end position
    /// </summary>
    public double ipg_end;//13
    /// <summary>
    /// ipg data acquisition count
    /// </summary>
    public int ipg_daqcount;//14
    /// <summary>
    /// ipg data acquisition count
    /// </summary>
    public double ipg_daqrange;//15

    public int ipg_daqDelay;
    public double ipg_daqSetvel;
}
*/
#endregion 

/// <summary>
/// 좌우 방향별 나뉘는 변수 구조체
/// </summary>
public struct tDevData
{
    /// <summary>
    /// 스트립 전체 두께 [mm]
    /// </summary>
    public double dTotalTh;
    /// <summary>
    /// 스트립 베이스 두께 [mm]
    /// </summary>
    public double dPcbTh;
    /// <summary>
    /// 스트립 몰드 두께 [mm]
    /// </summary>
    public double dMoldTh;

    // 200803 jym : Wheel file 연동 
    /// <summary>
    /// 휠 파일 이름
    /// </summary>
    public string sWhl;

    /// <summary>
    /// 드레싱 주기 [ea]
    /// </summary>
    public double dDrsPrid;
    /// <summary>
    /// Short 드레싱 주기 [ea]
    /// </summary>
    public int iShrtDrsPrd;
    /// <summary>
    /// Table spindle Factor Auto Dressing [%]
    /// </summary>
    public double dSpdAuto;
    /// <summary>
    /// Table spindle Factor Error [%]
    /// </summary>
    public double dSpdError;

    #region Step parameter
    /// <summary>
    /// 그라인딩 스타트 높이 방식
    /// </summary>
    public eGrdMode eGrdMod;

    /// <summary>
    /// 그라인딩 파라메터 배열
    /// </summary>
    public tStep[] aSteps;

    /// <summary>
    /// SW21N 그라인딩 파라미터 구조체 배열 최대 12step
    /// </summary>
    //public tNX_Step[] aNXSteps;

    /// <summary>
    /// TopDown Start Mode
    /// </summary>
    public eTDStartMode eStartMode; //190502 ksg :

    // 220110 : Spark Out
    /// <summary>
    /// 스트립 그라인딩 마지막 스텝 Spark Out 동작 카운트
    /// 마지막 스텝에서 지정된 Spark Out 카운트는 Z축 Down 없이 고정 위치에서 Y축만 반복 동작
    /// </summary>
    public int nSparkOutCnt;

    #endregion

    #region Contact
    public tCont[,] aPosBf;
    public tCont[,] aPosAf;
    public tCont[,] aMeas_Point;

    /// <summary>
    /// 그라인딩 전 자재 측정 시 리밋
    /// </summary>
    public double dBfLimit;
    /// <summary>
    /// 그라인딩 후 측정 시 리밋
    /// </summary>
    public double dAfLimit;
    /// <summary>
    /// 그라인딩 후 TTV 리밋
    /// </summary>
    public double dTTV;
    /// <summary>
    /// 그라인딩 후 TTV 리밋
    /// </summary>
    public double dOneLimit; //191018 ksg :
    /// <summary>
    /// One Point Checking 시 오버그라인딩 Range 설정
    /// </summary>
    public double dOneOver; // 2020.08.19 JSKim
    /// <summary>
    /// One Point Checking 시 측정 위치 변경시 X좌표 고정
    /// </summary>
    public bool bOnePointXPosFix; // 2020.08.31 JSKim
    /// <summary>
    /// One Point Checking 시 측정 Chip Window
    /// </summary>
    public int iOnePointWin; // 2020.08.31 JSKim
    /// <summary>
    /// One Point Checking 시 측정 Chip Col
    /// </summary>
    public int iOnePointCol; // 2020.08.31 JSKim
    /// <summary>
    /// One Point Checking 시 측정 Chip Col
    /// </summary>
    public int iOnePointRow; // 2020.08.31 JSKim
    #endregion

    #region ETC
    /// <summary>
    /// 탑클리너 버블 속도 [mm/s]
    /// </summary>
    public double dTpBubSpd;
    /// <summary>
    /// 탑클리너 버블 횟수
    /// </summary>
    public int iTpBubCnt;
    /// <summary>
    /// 탑클리너 에어 속도 [mm/s]
    /// </summary>
    public double dTpAirSpd;
    /// <summary>
    /// 탑클리너 에어 횟수
    /// </summary>
    public int iTpAirCnt;
    /// <summary>
    /// 탑클리너 스펀지 속도 [mm/s]
    /// </summary>
    public double dTpSpnSpd;
    /// <summary>
    /// 탑클리너 스펀지 횟수
    /// </summary>
    public int iTpSpnCnt;
    /// <summary>
    /// Left Probe RNR
    /// </summary>
    public double dPrbOffset;  //190502 ksg :
    /// <summary>
    /// 스트립 그라인딩 시 자재 절삭성에 의한 (Z축 Down -> 그라인딩 량)과 Target과의 편차 성분
    /// (-) : Under Grinding(더갈림) 경향이 있는 자재 -> Z축 Target 위치보다 더 Down 필요
    /// (+) : Over Grinding(더갈림) 경향이 있는 자재 -> Z축 Target 위치보다 더 Up 필요
    /// 2022.01.20.
    /// </summary>
    public double dGrdTargetOffset;
    /// <summary>
    /// Wheel Loss Update 기능 사용 시, 스트립 그라인딩 후 계산되는 Wheel Loss 량의 제한 범위 설정용
    /// 정상적인 경우 StagSequece._dWheelLossUpdate 값을 업데이트함
    /// 관련 옵션 : CData.Opt.bWheelLossCorrectionUse
    /// </summary>
    public double dWheelLossUpdateLimit;
    #endregion   
}

/// <summary>
/// 디바이스 전체적인 구조체
/// </summary>
public struct tDev
{
    /// <summary>
    /// 디바이스 이름
    /// </summary>
    public string sName;

    /// <summary>
    /// 마지막 수정 날짜
    /// </summary>
    public DateTime dtLast;

    /// <summary>
    /// Short Side 스트립의 짧은 부분 (가로)  [mm]
    /// </summary>
    public double dShSide;
    /// <summary>
    ///  Long Side 스트립의 긴 부분 (세로)  [mm]
    /// </summary>
    public double dLnSide;
    /// <summary>
    /// 듀얼모드 선택 변수
    /// </summary>
    public eDual bDual;
    /// <summary>
    /// NX 용 : Step Mode Grinding or Velocity Mode Grinding 선택
    /// </summary>
    public eGrindMode bGrindMode;
    /// <summary>
    /// Strip Dual 모드 일때 Top 또는 Btm 을 구분 하기 위함, 0 : TOP, 1: Btm
    /// </summary>
    public eTopSide eTopMoldSide;

    // 210722 : RecipeMode => Stage 1, 2 공통 항목으로 이동
    /// <summary>
    /// Recipe 스텝의 target 설정값이 total 두께 기준인지, mold 두께 기준인지 여부
    /// 참고 : 현 시점 본 속성 사용여부 미확정 (예비 속성으로 선 생성해 둠)
    /// </summary>
    public eRecipeMode eRcpMode;

    /// <summary>
    /// ReDoing mode
    /// 
    /// [Lv.1]
    ///   : 직전 동작의 under-grinding 량만큼 Z축 up하여 ReDoing 시작 => 시작 위치 up, 종료 위치 동일(step target)
    ///   
    ///   ReDoing Start 위치(up)  = (Z축 최종 위치) - (ReDoing Shift) - (잔량) <= 덜 갈린 양만큼 더 들어 올려 갈기 시작
    ///   ReDoing End 위치        = 해당 스텝 Z축 target 위치 (정규 step target 위치와 동일)
    ///   
    ///   => ReDoing 제한 횟수 도달 후에도 ReDoing 필요 시 잔량에 대해 다음 스텝에서 Z축 추가 up
    ///   => 정규 Step Z축 Start 위치 = (이전 스텝 Z축 최종 위치) - (AirCut) - (직전 그라인딩의 잔량)
    ///   => 정규 Step Z축 End 위치   = (해당 step의 tartget 위치) + (InDepth)
    ///   
    /// [Lv.2]
    ///   : 직전 동작의 under-grinding 량만큼 Z축 down하도록 ReDoing 동작
    ///
    ///   (WheelTip:Strip Contact 위치) = (테이블:휠팁 접점 Z축 위치) - (마지막 측정된 스트립 두께) <= 재계산 필수
    ///
    ///   ReDoing Start 위치      = (WheelTip:Strip Contact 위치) - (ReDoing Shift)
    ///   ReDoing End 위치(down)  = (재 측정된 WheelTip:Strip Contact 위치) + (잔량) <= One Point 측정 두께를 기준으로 재계산 필수
    ///   
    ///   => 정규 Step Z축 Start 위치 = (WheelTip:Strip Contact 위치) - (AirCut)
    ///   => 정규 Step Z축 End 위치   = (해당 step의 tartget 위치) + (InDepth)
    ///   
    ///   : [Lv.2] ReDoing End 위치(down) 계산은, 분석용 로그만 남기고 실제 적용은 [Lv.2-1] 방식으로 진행
    ///   
    /// [Lv.2-1]
    ///   : 정규 Step 및 ReDoing Z축 Start 위치 = [LV.2]와 동일,
    ///   : 단, ReDoing End 위치 = (직전 그라인딩의 Z축 최종 위치) + (under-grinding 량)
    ///                          = (Z축 최종 위치) + (잔량) 
    ///
    /// [Lv.3]
    ///   SPH 최적화 : 정규스텝/ReDoing 무관 Z축 Start 위치 = (직전 그라인딩의 Z축 최종 위치) - (AirCut 또는 ReDoing Shift)
    ///   첫 정규스텝인 경우 (직전 그라인딩의 Z축 최종 위치) 값은 Before Measure 여부 조건에 따라 측정/Spec. 스트립 두께 기준으로 계산됨
    ///
    ///   ReDoing End 위치 = [Lv.2-1] 방식과 동일
    ///
    /// [Lv.3-1]
    ///   [Lv.3]과 하기 사항만 차별화
    ///   첫 스텝을 제외한 정규 Step Z축 End 위치 = (직전 그라인딩의 Z축 최종 위치) + (현 스텝 그라인딩 량)
    /// 
    /// </summary>
    public eReDoLevel eRedoMode;

    /// <summary>
    /// 좌우 나뉘는 변수들 구조체 배열,    0:좌    1:우
    /// </summary>
    public tDevData[] aData;

    #region DF
    /// <summary>
    /// DF 측정 시 Align 조정 옵셋. 기존 얼라인포지션 + 옵셋. [mm]
    /// </summary>
    public double dfAlignOffset;
    #endregion

    #region Contact
    /// <summary>
    /// Column Count 자재 측정위치 Column 개수 (칩의 개수) [ea]
    /// </summary>
    public int iCol;
    /// <summary>
    /// Row Count 자재 측정위치 Row 개수 (칩의 개수) [ea]
    /// </summary>
    public int iRow;
    /// <summary>
    /// Chip Width 칩 자체의 가로 길이 [mm]
    /// </summary>
    public double dChipW;
    /// <summary>
    /// Chip Height 칩 자체의 세로 길이 [mm]
    /// </summary>
    public double dChipH;
    /// <summary>
    /// Unit에서 가로 길이의 옵셋 [mm],  +값은 가로길이 증가, -값은 가로길이 감소
    /// </summary>
    public double UnitWOffset;
    /// <summary>
    /// Unit에서 세로 길이의 옵셋 [mm],  +값은 세로길이 증가, -값은 세로길이 감소
    /// </summary>
    public double UnitHOffset;

    /// <summary>
    /// Chip Width Gap 칩간의 가로 간격, 1번째 칩 중앙에서 우측 칩 중앙까지 거리 [mm]
    /// </summary>
    public double dChipWGap;
    /// <summary>
    /// Chip Height Gap 칩간의 세로 간격, 1번째 칩 중앙에서 아래쪽 칩 중앙까지 거리 [mm]
    /// </summary>
    public double dChipHGap;
    /// <summary>
    /// Window Count 윈도우 갯수, 최대 5개
    /// </summary>
    public int iWinCnt;
    /// <summary>
    /// Window Start Point Array 각 윈도우의 좌상점 위치, 최대 5개 [mm]
    /// </summary>
    public PointF[] aWinSt;
    #endregion

    #region ETC
    /// <summary>
    /// Magazine Count 매거진 1개에 들어가는 자재 갯수 [ea]
    /// </summary>
    public int iMgzCnt;
    /// <summary>
    /// Magazine Pitch 매거진 슬롯간 간격 사이즈 [mm]
    /// </summary>
    public double dMgzPitch;

    public int iMgzDir;
    /// <summary>
    /// Use Dry Top Blow 드라이 탑 블로우 사용 유무
    /// </summary>
    public bool bDryTop;
    /// <summary>
    /// Dry Speed 드라이 속도 [rpm]
    /// </summary>
    public int iDryRPM;
    /// <summary>
    /// Dry Direction 드라이 회전 방향
    /// </summary>
    public eDryDir eDryDir;
    /// <summary>
    /// Dry Count 드라이 횟수 [ea]
    /// </summary>
    public int iDryCnt;
    /// <summary>
    /// 드라이 실린더 타입에서 워터 노즐 동작 시 속도 [rpm]
    /// </summary>
    public int wtrVel;
    /// <summary>
    /// 드라이 실린더 타입에서 워터 노즐 동작 시 카운트 [ea]
    /// </summary>
    public int wtrCnt;

    /// <summary>
    /// Bottom Cleaner Cleaning Strip Count
    /// 바텀 클리너에 스트립 바닦면을 닦는 횟수 [ea]
    /// </summary>
    public int iOffpCleanStrip;

    /// <summary>
    /// On Loader Picker Vacuum Delay [ms]
    /// </summary>
    public int iPickDelayOn;
    /// <summary>
    /// On Loader Picker Place Vacuum Delay [ms]
    /// </summary>
    public int iPlaceDelayOn;
    /// <summary>
    /// Off Loader Picker Vacuum Delay [ms]
    /// </summary>
    public int iPickDelayOff;
    //20200427 jhc : <<--- 200417 jym : Unit에서는 설정된 딜레이 값 사용
    /// <summary>
    /// Off Loader Picker Place Vacuum Delay [ms]
    /// </summary>
    public int iPlaceDelayOff;
    //
    /// <summary>
    /// Barcode 사용 유무 true:skip, false:use
    /// </summary>
    public bool bBcrSkip;
    /// <summary>
    /// Orientation 사용 유무 true:skip, false:use
    /// </summary>
    public bool bOriSkip;

    /// <summary>
    /// SECS/GEM을 통한 HOST로의 Verify를 수행하지 않는다.  true:Skip,  false:use
    /// </summary>
    public bool bVerifySkip;

    /// <summary>
    /// SECS/GEM을 통한 HOST로의 MGZ Verify를 수행하지 않는다.  true:Skip,  false:use
    /// </summary>
    public bool bMgzVerifySkip;

    /// <summary>
    /// Mgz barcode reading을 Skip 한다.  true:Skip,  false:use
    /// </summary>
    public bool bMgzBcrSkip;

    // [DF]
    /// <summary>
    /// Dynamic Function 사용 유무 true:skip, false:use
    /// </summary>
    public bool bDynamicSkip;
    /// <summary>
    /// 그라인딩 시 적용 될 PCB 측정 값
    /// 0 : MAX, 1 : MEAN
    /// </summary>
    public int iPcbThickSelect;
    /// <summary>
    /// PCB 측정 값 에러 범위 (SECS/GEM Host에서 download된 값 포함)
    /// </summary>
    public double dPcbRange;
    /// <summary>
    /// PCB 측정 값 Mean 에러 범위 (SECS/GEM Host에서 download된 값 포함)
    /// </summary>
    public double dPcbMeanRange;
    //........

    //20190309 ksg : Ocr 추가
    /// <summary>
    /// Ocr Function 사용 유무 true:skip, false:use
    /// </summary>
    public bool bOcrSkip;

    /// <summary>
    /// Bcr Manual Key In
    /// </summary>
    public bool bBcrKeyInSkip;

    /// <summary>
    /// Wheel RFID Key 검사
    /// </summary>
    public bool bWhlRfidVeiifySkip;

    /// <summary>
    /// 온로더 피커 워터 클리닝 카운트(2000NX)
    /// </summary>
    public int iOnpWCleanCnt;
    /// <summary>
    /// 온로더 피커 에어 클리닝 카운트
    /// </summary>
    public int iOnpACleanCnt;
    /// <summary>
    /// 오프로더 피커 워터 크리닝 카운트
    /// </summary>
    public int iOfpWCleanCnt;
    /// <summary>
    /// 오프로더 피커 에어 크리닝 카운트
    /// </summary>
    public int iOfpACleanCnt;
    #endregion

    #region SW21N IPG
    /// <summary>
    /// 그라인딩 중 TABLE을 IPG로 측정 할때 Y축 포지션
    /// </summary>
    public double[] dIpgTablePos;
    /// <summary>
    /// 그라인딩 중 STRIP을 IPG로 측정 할때 Y축 포지션
    /// </summary>
    public double[] dIpgStripPos;
    #endregion

    #region SW21N Laser Strip Measure
    /// <summary>
    /// Laser->Strip Chip 단위 측정 시 Target Mode 사용 여부
    /// Step(1 point) measure 시 옵션
    /// </summary>
    public bool [] bLaserStripMeaTargetMode_1P;
    /// <summary>
    /// Laser->Strip Chip 단위 측정 시 Target Mode 사용 여부
    /// After measure 시 옵션
    /// </summary>
    public bool [] bLaserStripMeaTargetMode_AF;
    #endregion

    #region Loader Position
    /// <summary>
    /// MGZ 고정 위치
    /// 입력불가
    /// 계산
    /// </summary>
    public double dOnL_X_Algn;
    /// <summary>
    /// 대기위치 & 자재 투입위치
    /// </summary>
    public double dOnL_Y_Wait;

    // SG1003U의 Rail 3개에 대응
    public double dOnL_Y_Wait2;         // 2번쨰 Rail 자재 투입위치
    public double dOnL_Y_Wait3;         // 3번쨰 Rail 자재 투입위치


    /// <summary>
    /// AGV TR 사용시 TR Rail로 제품을 밀어주는 Push 위치
    /// SG1004U ~
    /// </summary>
    public double dOnL_X_Push1;         // MGZ -> TR Rail Stopper까지 Push
    public double dOnL_X_Push2;         // TR Rail -> InRail까지 Push

    //20200608 jhc : KEYENCE BCR (On/Off-로더 매거진 바코드)
    /// <summary>
    /// MGZ Barcode 읽는 위치
    /// </summary>
    public double dOnL_Y_MgzBcr;
    //
    /// <summary>
    /// 자재 투입 최초 위치
    /// 아래부터 투입
    /// </summary>
    public double dOnL_Z_Entry_Dn;
    /// <summary>
    /// 자재 투입 최초 위치
    /// 입력불가
    /// 계산 (dOnL_Z_Entry_Dn 값으로 자동 계산됨)
    /// </summary>
    public double dOnL_Z_Entry_Up;
    //20200608 jhc : KEYENCE BCR (On/Off-로더 매거진 바코드)
    /// <summary>
    /// MGZ Barcode 읽는 위치
    /// </summary>
    public double dOnL_Z_MgzBcr;

    /// <summary>
    /// AGV 대응, MGZ Lock check 위치
    /// </summary>
    public double dOnL_Y_LockCheck;
    public double dOnL_Z_LockCheck;

    /// <summary>
    /// AGV 대응, MGZ Lock/Unlock 동작 안전 위치
    /// </summary>
    public double dOnL_Y_LockAction;
    public double dOnL_Z_LockAction;

    /// <summary>
    /// AGV 적용시 Transfer 축 이동 위치
    /// SG1004U ~ 
    /// </summary>
    // Transfer Y축 이동 위치
    public double dOnL_TR_Work;             // TR -> InRail 전달위치
    public double dOnL_TR_Rail1;            // MGZ -> TR Rail1 위치
    public double dOnL_TR_Rail2;            // MGZ -> TR Rail2 위치
    public double dOnL_TR_Rail3;            // MGZ -> TR Rail3 위치

    /// <summary>
    /// AGV Magazine Lock 장치
    /// SG1004U ~ 
    /// </summary>
    public double dOnL_MgzLock_Wait;        // Magazine Lock 대기위치
    public double dOnL_MgzLock_Unlock;      // Magazine Lock 잠금 해제 위치

    public double LElvPX_Push;

    #endregion

    #region Inrail Position
    #region Inrail X
    public double dInr_X_Pick;
    public double dInr_X_Bcr;
    public double dInr_X_Ori; //190211 ksg : 추가
    public double dInr_X_Vision;
    public double dInr_X_Align;

    public double[] inrX_DfPos;
    /// <summary>
    /// <summary>
    /// Device > SET POSITION > InRail > Dynamic Function 1~5 Position에 설정된 값에 따라 실제 DF 포지션 수가 결정됨
    /// DynamicPos1~3 입력 필수 (즉, DF 측정 포지션 수는 최소 3개 이상이어야 함),
    /// DF 사용 활성화 옵션(!CData.Dev.bDynamicSkip && CDataOption.MeasureDf == eDfServerType.MeasureDf)일 때,
    /// (DynamicPos1 == 0) || (DynamicPos2 == 0) || (DynamicPos3 == 0) => Error, DF 포지션 수: 3개로 설정됨,
    /// DynamicPos4 == 0, DynamicPos5 == 0 => DF 포지션 수: 3개로 설정됨,
    /// DynamicPos4 != 0, DynamicPos5 == 0 => DF 포지션 수: 4개로 설정됨,
    /// DynamicPos4 == 0, DynamicPos5 != 0 => DF 포지션 수: 4개로 설정됨, DynamicPos5의 값이 DynamicPos4에 할당됨
    /// DynamicPos4 != 0, DynamicPos5 != 0 => DF 포지션 수: 5개로 설정됨,
    /// Default = 3개
    /// </summary>
    public int iDynamicPosNum;
    //
    #endregion

    #region Inrail Y
    public double dInr_Y_Align;
    /// <summary>
    /// 자재 투입 시 Align포지션에 적용되는 값 [mm] (Lift Motor에서만 사용)
    /// Align포지션 - InputGap = 자재 투입시 포지션
    /// </summary>
    public double RailY_InputGap;
    /// <summary>
    /// 피커가 자재 가져갈 때 Align포지션에 적용되는 값 [mm] (Lift Motor에서만 사용)
    /// Align포지션 - ReleaseGap = 자재 피커로 이동 시 포지션
    /// </summary>
    public double RailY_ReleaseGap;

    #endregion

    #region Inrail Z
    public double RailZ_Vacuum;        //Inrail lift up position
    
    #endregion
    #endregion

    #region On Loader Picker Position    
    public double dOnP_Z_Pick;
    public double dOnP_Z_Place;
    public double dOnP_Z_Slow;    

    public double dOnp_X_Bcr;
    public double dOnp_X_Ori;
    public double dOnp_X_BcrSecon;
    public double dOnp_Z_Bcr;
    public double dOnp_Z_Ori;
    public double dOnp_Y_Bcr;
    public double dOnp_Y_Ori;
    public double dOnp_Y_BcrSecon; 

    public double dOnp_X_Bcr_TbL;
    public double dOnp_X_Ori_TbL;
    public double dOnp_X_Bcr_TbR;
    public double dOnp_X_Ori_TbR;
    public double dOnp_Z_Bcr_TbL;
    public double dOnp_Z_Ori_TbL;
    public double dOnp_Z_Bcr_TbR;
    public double dOnp_Z_Ori_TbR;
    public double dOnp_Y_Bcr_TbL;
    public double dOnp_Y_Ori_TbL;
    public double dOnp_Y_Bcr_TbR;
    public double dOnp_Y_Ori_TbR;

    public double dOnp_Y_RailPitch;     // BCR/Ori 읽을시, 1번쨰 기준위치로부터 Y축을 Rail별로 이동시킬 Pitch, Rail 번호로 자동 계산

    public double dOnp_X_Clean;
    public double dOnp_Z_Clean;
    #endregion

    #region Grind Position Array
    public double[] aGrd_Y_Start;
    public double[] aGrd_Y_End;
    public double[] aGrd_Y_Ori;

    public double[] StagX_Offset;

    #endregion

    #region Off Loader Picker Potion
    public double dOffP_X_ClnStart;
    public double dOffP_X_ClnEnd;
    public double dOffP_Z_Pick;
    public double dOffP_Z_Place;
    public double dOffP_Z_Slow;
    public double dOffP_Z_PlaceDn;
    public double UPnpZ_CleanStrip;
    //220209 HJP IV
    public double dUpnp_X_VisionFront;
    public double dUpnp_X_VisionRear;
    public double dUpnp_Y_VisionFront;
    public double dUpnp_Y_VisionRear;
    public double dUpnp_Z_Picture;
    #endregion

    #region Dry Position
    public double dDry_R_Check1;
    public double dDry_R_Check2;
    //220117 HJP 자재 감지 유무 체크
    public double dDry_Z_CheckStrip;

    // 211230 syc : 21B Dry
    /// <summary>
    /// 1000U Dry Work Start Position
    /// </summary>
    public double dDry_Air_Start;
    /// <summary>
    /// 1000U Dry Work End Position
    /// </summary>
    public double dDry_Air_End;
    /// <summary>
    /// Dry Work 위치로 Unit을 이동시키기 위한 Dry X축 Position
    /// </summary>
    public double dDry_X_Align;
    /// <summary>
    /// 1000U Slow Out 위치
    /// </summary>
    public double dDry_X_BeforeOut;
    //
    #endregion

    #region Off Loader Position
    /// <summary>
    /// MGZ 고정 위치
    /// 입력불가
    /// 계산
    /// </summary>
    public double dOffL_X_Algn;

    /// <summary>
    /// 대기위치 & 자재 받는위치
    /// </summary>
    public double dOffL_Y_Wait;

    // SG1000U의 Rail 3개에 대응
    // SG1003U
    public double dOffL_Y_Wait2;         // 2번쨰 Rail 자재 배출위치
    public double dOffL_Y_Wait3;         // 3번쨰 Rail 자재 배출위치

    /// <summary>
    /// AGV TR 사용시 TR Rail -> MGZ 으로 제품을 밀어주는 Push 위치
    /// SG1004U ~ 
    /// </summary>
    public double dOffL_X_Push1;         // Pusher Pass Sensor 위치, 이 위치 이후로는 감속 이동을 한다.
    public double dOffL_X_Push2;         // Pusher Mgz push 위치


    //20200608 jhc : KEYENCE BCR (On/Off-로더 매거진 바코드)
    /// <summary>
    /// MGZ Barcode 읽는 위치
    /// </summary>
    public double dOffL_Y_MgzBcr;
    //
    /// <summary>
    /// 자재 투입 최초 위치
    /// 아래부터 투입
    /// </summary>
    public double dOffL_Z_TRcv_Dn;
    /// <summary>
    /// 자재 투입 최초 위치
    /// 입력불가
    /// 계산
    /// </summary>
    public double dOffL_Z_TRcv_Up;
    /// <summary>
    /// 자재 투입 최초 위치
    /// 아래부터 투입
    /// </summary>
    public double dOffL_Z_BRcv_Dn;
    /// <summary>
    /// 자재 투입 최초 위치
    /// 입력불가
    /// 계산
    /// </summary>
    public double dOffL_Z_BRcv_Up;
    /// <summary>
    /// 자재 투입 위치(Slot기준)
    /// 입력 불가
    /// 계산
    /// </summary>
    public double dOffL_Z_Work;
    //20200608 jhc : KEYENCE BCR (On/Off-로더 매거진 바코드)
    /// <summary>
    /// MGZ Barcode 읽는 위치
    /// </summary>
    public double dOffL_Z_MgzBcr;


    /// <summary>
    /// AGV 대응, MGZ Lock check 위치
    /// </summary>
    public double dOffL_Y_LockCheck;
    public double dOffL_Z_LockCheck;

    /// <summary>
    /// AGV 대응, MGZ Lock/Unlock 수행 위치
    /// </summary>
    public double dOffL_Y_LockAction;
    public double dOffL_Z_LockAction;


    /// <summary>
    /// AGV Transfer Y축 이동 위치
    /// SG1004U ~ 
    /// </summary>
    public double dOffL_TR_Work;             // Dryzone -> TR InRail 전달위치
    public double dOffL_TR_Rail1;            //  TR Rail1 -> MGZ위치
    public double dOffL_TR_Rail2;            //  TR Rail2 -> MGZ위치
    public double dOffL_TR_Rail3;            //  TR Rail3 -> MGZ위치


    //
    #endregion

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
        this = (tDev)obj;
    }

    public void SetVal(string name, object val, int index)
    {
        object obj = this;
        IList arr = (IList)GetType().GetField(name).GetValue(obj);
        arr[index] = val;
        GetType().GetField(name).SetValue(obj, arr);
        this = (tDev)obj;
    }
}
