#pragma once

#include <set>
// Copyright (c) Google LLC 2019
// Tiszai Istvan
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

#include <vector>
#include <string>
#include <brunsli\jpeg_data.h>
#include <brunsli/jpeg_data_reader.h>

using namespace System;
using namespace brunsli;

namespace brunslinetwrapper {
	public ref class BrunsliWrapper
	{		
		public:
		// ctor
			BrunsliWrapper(){};
		// methods
			array<Byte>^ EncodeJpeg( array<Byte>^ indata );
			array<Byte>^ DecodeJpeg( array<Byte>^ indata );
		private:
			array<Byte>^ ToByteArray(const std::string& rdatastr);
			unsigned char* ToCharArray(array<System::Byte>^ byteArray);			
	};
}

  
