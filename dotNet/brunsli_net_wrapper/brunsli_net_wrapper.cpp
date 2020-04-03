// Copyright (c) Google LLC 2019
// Tiszai Istvan
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

#include "pch.h"
#include <msclr\marshal_cppstd.h>
#include "brunsli_net_wrapper.h"
#include <brunsli/brunsli_decode.h>
#include <brunsli/jpeg_data_writer.h>
#include <brunsli/brunsli_encode.h>

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

int StringWriter(void* data, const uint8_t* buf, size_t count) {
  std::string* _output = reinterpret_cast<std::string*>(data);
  _output->append(reinterpret_cast<const char*>(buf), count);
  return count;
}

namespace brunslinetwrapper {
array<Byte>^ BrunsliWrapper::ToByteArray(const std::string& rdatastr) {
    array<Byte>^ _data = gcnew array<Byte>(rdatastr.size());
    for (int ii = 0; ii < rdatastr.size(); ii++)
    {
        _data[ii] = rdatastr.c_str()[ii];
    }
    return _data;
}

unsigned char* BrunsliWrapper::ToCharArray(array<System::Byte>^ byteArray) {
    pin_ptr<Byte> _data = &byteArray[0];
    unsigned char* _rdata = _data;
    return _rdata;
}

array<Byte>^ BrunsliWrapper::DecodeJpeg(array<Byte>^ indata) {
    uint8_t* _data = ToCharArray(indata);
    int _st =0;
    if (_data == NULL) return nullptr;
    int _length = indata->Length;
    if (_length <= 0) return nullptr;
    ::brunsli::JPEGData _jpg;
    ::brunsli::BrunsliStatus status = ::brunsli::BrunsliDecodeJpeg(_data, _length, &_jpg);
    _st = status;
    if (status != ::brunsli::BRUNSLI_OK) {

        return nullptr;
    }
    std::string _output;
    ::brunsli::JPEGOutput writer(StringWriter, &_output);
    if (!::brunsli::WriteJpeg(_jpg, writer)) {
        return nullptr;
    }  
    return ToByteArray(_output);
}

array<Byte>^ BrunsliWrapper::EncodeJpeg(array<Byte>^ indata) {
    uint8_t* _data = ToCharArray(indata);
    bool _ok;
    if (_data == NULL) return nullptr;
    int _length = indata->Length;
    if (_length <= 0) return nullptr;
    ::brunsli::JPEGData _jpg;
    _ok = brunsli::ReadJpeg(_data, indata->Length, brunsli::JPEG_READ_ALL, &_jpg);
     if (!_ok) {
        return nullptr;
     }
    std::string _output;
    size_t _output_size = brunsli::GetMaximumBrunsliEncodedSize(_jpg);
    _output.resize(_output_size);
     uint8_t* _output_data = reinterpret_cast<uint8_t*>(&_output[0]);   
    _ok = brunsli::BrunsliEncodeJpeg(_jpg, _output_data, &_output_size);
     if (!_ok) {
        return nullptr;
    }
    _output.resize(_output_size);
     return ToByteArray(_output);
}
}


