// これは メイン DLL ファイルです。

#include "stdafx.h"

#include "cursorDLL.h"


using namespace cursorDLL;

cursorControl::cursorControl() {
	normalCursor = CopyCursor(LoadCursor(NULL, IDC_ARROW));
}

bool cursorControl::SetBigCursor() {
	HINSTANCE hInst = GetModuleHandle(NULL);

	HCURSOR tmp = (HCURSOR)LoadImage(NULL, TEXT("./bigcur.cur"), IMAGE_CURSOR, 0, 0,
		LR_CREATEDIBSECTION | LR_DEFAULTSIZE | LR_LOADFROMFILE);
	if (NULL == tmp) {
		return false;
	}

	if (false == SetSystemCursor(tmp, OCR_NORMAL)) {
		return false;
	}

	return true;
}

bool cursorControl::SetDefaultCursor() {

	if (false == SetSystemCursor(CopyCursor(normalCursor), OCR_NORMAL)) {
		return false;
	}
	return true;
}
