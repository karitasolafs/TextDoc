using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace TextDuck.UF
{
        public class ValidateFileAttribute : RequiredAttribute
        {
            public override bool IsValid(object value)
            {
                var file = value as HttpPostedFileBase;
                if (file == null)
                {
                    return false;
                }

                try
                {
                    using (var img = Image.FromStream(file.InputStream))
                    {
                        return img.RawFormat.Equals(ImageFormat.Png);
                    }
                }
                catch { }
                return false;
            }
    }
}