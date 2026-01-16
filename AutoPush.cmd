@echo off
@title GIT 自动推送到远程仓库

set basedir="%~dp0"
set basedir


@echo\&echo 推送到 GitHub 远程仓库
git push github --all

@echo\&echo 推送到 Gitee 远程仓库
git push gitee --all

@echo\&echo 推送到 GitCode 远程仓库
git push gitcode --all

::@echo\&echo 推送到 Bitbucket 远程仓库
::git push bitbucket --all

::@echo\&echo 推送到 Azure 远程仓库
::git push azure --all

::@echo\&echo 推送到 Origin 远程仓库
::git push origin --all

@echo\&echo 查看本地仓库状态
git status


@echo.
@echo.
@echo.
@echo.
@echo.
@echo\&echo 完成所有远程仓库推送，请按任意键退出。
pause>nul 
exit