del /s /q ..\public
md ..\public
xcopy *.* ..\public /EXCLUDE:publicExclude.txt /e
copy GameData\GameParametersPublic.xml ..\public\GameData\GameParameters.xml
copy GameData\GlobalVariablesPublic.xml ..\public\GameData\GlobalVariables.xml
xcopy Resources\CreateChildrenTextFile\Public ..\public\Resources\CreateChildrenTextFile
md ..\public\GameComponents\PersonPortrait\Images\Player
copy GameComponents\PersonPortrait\PlayerImage\9999.jpg ..\public\GameComponents\PersonPortrait\PlayerImage\9999.jpg
copy GameComponents\PersonPortrait\PlayerImage\9999s.jpg ..\public\GameComponents\PersonPortrait\PlayerImage\9999s.jpg
copy GameComponents\PersonPortrait\PlayerImage\ReadMe.txt ..\public\GameComponents\PersonPortrait\PlayerImage\ReadMe.txt
md ..\public\GameData\Save
md ..\public\Resources\Extensions
