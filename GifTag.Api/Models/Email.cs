using System.Collections.Generic;

public class EmailDto
{
    public IEnumerable<EmailAttachmentDto> Attachments { get; set; }
    public string Body { get; set; }
    public string EmailAddress { get; set; }
    public string Subject { get; set; }
}
public class EmailAttachmentDto
{
    public string Name { get; set; }
    public string Path { get; set; }
}