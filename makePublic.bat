del /s /q ..\public
md ..\public
xcopy *.* ..\public /EXCLUDE:publicExclude.txt /e
