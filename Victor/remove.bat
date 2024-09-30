@echo off
echo ----------------------------------------------------
echo Visual Studio 관련하여 필요없는 파일을 모두 지웁니다. 
echo *.aps *.idb *.ncp *.suo *.obj *.pch *.sbr *.tmp *.pdb *.bsc *.ilk *.res *.ncb
echo *.opt *.suo *.manifest *.dep *.map *.bak *.sin *.exp *.user *.htm *.VC.db *.ipch *.tlog
echo *.iobj *.ipdb *.sdf
echo made by CYLIM
echo ----------------------------------------------------
pause

del /F /S /Q /A *.aps *.idb *.ncp *.suo *.obj *.pch *.sbr *.tmp *.pdb *.bsc *.ilk *.res *.tlog *.Build.CppClean.log
del /F /S /Q /A *.ncb *.opt *.suo *.manifest *.dep *.map *.bak *.sin *.exp *.user *.htm *.VC.db *.ipch
del /F /S /Q /A *.iobj *.ipdb *.opendb *.sdf *.log *.lastbuildstate *.enc

rmdir /S /Q ipch
rmdir /S /Q .vs
rmdir /S /Q ./obj

pause
