﻿/*
MIT License

Copyright (c) [2020] [Jose Roberto Taveras Galvan]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using BusinessObjects.Interfaces;
using BusinessObjects.Resources;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public class Vendor : IVendor
    {
        public int Id { get; set; }
        [MaxLength(70, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string VendName { get; set; }
        [MaxLength(120, ErrorMessageResourceName = "MaxLengthErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceName = "RequiredErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string Adress { get; set; }
        public bool Status { get; set; }
        public int VendorTypeId { get; set; }
        public virtual VendorType VendorType { get; set; }
    }
}
