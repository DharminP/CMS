namespace CMSAPI.Models;

public class Policy
{
    public int pid { get; set; }
    public string pname { get; set; } = "";
    public string ptype { get; set; } = "";
    public int pgrade { get; set; }
    public string pstatus { get; set; } = "";

    public string pdesc_short { get; set; } = "";

    public string pdesc { get; set; } = "";

    public int pCoverage { get; set; }
    public int pPremium { get; set; }

    public string gender { get; set; } = "";
    public string ageGroup { get; set; } = "";
    public string members { get; set; } = "";
    public string insurer { get; set; } = "";
    



}
