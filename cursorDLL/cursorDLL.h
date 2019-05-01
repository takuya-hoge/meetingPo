// cursorDLL.h

#pragma once
#define OEMRESOURCE
#include<Windows.h>

using namespace System;

namespace cursorDLL {

	public ref class cursorControl
	{
		HCURSOR normalCursor;

	public:
		cursorControl();

		bool SetBigCursor();

		bool SetDefaultCursor();
	};
}
