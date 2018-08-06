namespace GifTag.Api.Points
{
    public static class PointFactory
    {
        public static Points Get(string template)
        {
            switch (template)
            {
                case "boarding-pass-1.jpg":
                    return new Template_1();
                case "boarding-pass-2.jpg":
                    return new Template_2();
                case "template_3":
                    return new Template_3();
                default:
                    return new Template_1();
            }
        }
    }
}
