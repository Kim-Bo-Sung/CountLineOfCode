namespace MyCommon
{
    // FileName 메서드와 Code 메소드를 포함하는 MyString 클래스.
    // FileName 메서드: S/W에서 처리하는 세 가지 파일 이름을 자동 생성해주는 메서드.
    public static class MyString
    {
        private static string _str = string.Empty;

        public static string FileName(string str)
        {
            switch (str)
            {
                default:
                    _str = str;
                    return _str;
            }
        }

        // Code 메소드: 4자리 16진수로, 해당 코드 메시지를 리턴해주는 메서드.
        public static string Code(string str)
        {
            switch (str)
            {
                case "0099":
                    _str = "0099:\rCountLineOfCode, ver. 1.0.0\r(producted by bskim)";
                    return _str;
                default:
                    _str = "Wrong string code is found!.";
                    return _str;
            }
        }
    }
}
