/***********************************************************************
 * <copyright file="ConverterString.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, May 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    /// <summary>
    /// Convert TCVN3 to Unicode font
    /// </summary>
    public class ConvertFont
    {
        /// <summary>
        /// The tcvnchars
        /// </summary>
        private static readonly char[] TCVN3Chars = {
                                                    'µ', '¸', '¶', '·', '¹', 
                                                    '¨', '»', '¾', '¼', '½', 'Æ', 
                                                    '©', 'Ç', 'Ê', 'È', 'É', 'Ë', 
                                                    '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ', 
                                                    'ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö', 
                                                    '×', 'Ý', 'Ø', 'Ü', 'Þ', 
                                                    'ß', 'ã', 'á', 'â', 'ä', 
                                                    '«', 'å', 'è', 'æ', 'ç', 'é', 
                                                    '¬', 'ê', 'í', 'ë', 'ì', 'î', 
                                                    'ï', 'ó', 'ñ', 'ò', 'ô', 
                                                    '­', 'õ', 'ø', 'ö', '÷', 'ù', 
                                                    'ú', 'ý', 'û', 'ü', 'þ', 
                                                    '¡', '¢', '§', '£', '¤', '¥', '¦'
                                                    };

        /// <summary>
        /// The unichars
        /// </summary>
        private static readonly char[] UnicodeChars = {
                                                    'à', 'á', 'ả', 'ã', 'ạ', 
                                                    'ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ', 
                                                    'â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ', 
                                                    'đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ', 
                                                    'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ', 
                                                    'ì', 'í', 'ỉ', 'ĩ', 'ị', 
                                                    'ò', 'ó', 'ỏ', 'õ', 'ọ', 
                                                    'ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ', 
                                                    'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ', 
                                                    'ù', 'ú', 'ủ', 'ũ', 'ụ', 
                                                    'ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự', 
                                                    'ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ', 
                                                    'Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'
                                                    };

        /// <summary>
        /// The convert table
        /// </summary>
        private static readonly char[] ConvertTable;

        /// <summary>
        /// Initializes the <see cref="ConvertFont"/> class.
        /// </summary>
        static ConvertFont()
        {
            ConvertTable = new char[256];
            for (int i = 0; i < 256; i++)
                ConvertTable[i] = (char)i;
            for (int i = 0; i < TCVN3Chars.Length; i++)
                ConvertTable[TCVN3Chars[i]] = UnicodeChars[i];
        }

        /// <summary>
        /// TCVs the n3 to unicode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string TCVN3ToUnicode(string value)
        {
            char[] chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                if (chars[i] < (char)256)
                    chars[i] = ConvertTable[chars[i]];
            return new string(chars);
        }
    }

}
