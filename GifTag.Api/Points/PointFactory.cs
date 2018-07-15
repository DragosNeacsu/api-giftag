namespace GifTag.Api.Points
{
    public static class PointFactory
    {
        public static Points Get(string template)
        {
            switch (template)
            {
                case "template_1":
                    return new Template_1();
                case "template_2":
                    return new Template_1();
                case "template_3":
                default:
                    return new Template_1();
            }
        }
    }
}
