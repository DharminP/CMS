using CMSAPI.Models;

public class PolicyRepository : IPolicyRepository
{
    private List<Policy> _Policies;
    public PolicyRepository()
    {
        _Policies = new List<Policy>();
        _Policies.Add(new Policy
        {
            pid = 1,
            pname = "GMCPolicy1",
            ptype = "GMC",
            pgrade = 12,
            pstatus = "Active",
            pCoverage = 10000,
            pdesc = "This is policy description.",
            pdesc_short = "This is short description.",
            pPremium = 1000,
            gender = "M",
            insurer = "HDFC",
            members = "Spouse",
            ageGroup = "30"

        });
        _Policies.Add(new Policy
        {
            pid = 2,
            pname = "GPAPolicy1",
            ptype = "GPA",
            pgrade = 11,
            pstatus = "Active",
            pCoverage = 10000,
            pdesc = "This is policy description.",
            pdesc_short = "This is short description.",
            pPremium = 1000,
            gender = "M",
            insurer = "ICICI",
            members = "Spouse",
            ageGroup = "30"
        });
        _Policies.Add(new Policy
        {
            pid = 3,
            pname = "GTLPolicy1",
            ptype = "GTL",
            pgrade = 10,
            pstatus = "Active",
            pCoverage = 10000,
            pdesc = "This is policy description.",
            pdesc_short = "This is short description.",
            pPremium = 1000,
            gender = "M",
            insurer = "HDFC",
            members = "Child",
            ageGroup = "30"
        });
        _Policies.Add(new Policy
        {
            pid = 4,
            pname = "GTLPolicy2",
            ptype = "GTL",
            pgrade = 1,
            pstatus = "Active",
            pCoverage = 10000,
            pdesc = "This is policy description.",
            pdesc_short = "This is short description.",
            pPremium = 1000,
            gender = "M",
            insurer = "ICICI",
            members = "Spouse",
            ageGroup = "30"
        });
    }
    public List<Policy> CreatePolicy(Policy policy)
    {
        int NoOfRecords = _Policies.Count();
        policy.pid = 1;
        if (NoOfRecords > 0)
        {
            policy.pid = _Policies.Max(p => p.pid) + 1;
        }
        _Policies.Add(policy);
        return _Policies;

    }

    public List<Policy> DeletePolicy(int pid)
    {
        var result = _Policies.Where(p => p.pid == pid).FirstOrDefault();
        if (result != null)
        {
            _Policies.Remove(result);
        }
        return _Policies;
    }

    public List<Policy> GetPolicies()
    {
        return _Policies.OrderBy(x=>x.pstatus).ToList();
    }

    public Policy GetPolicyById(int pid)
    {
        Policy policy = new Policy();
        var result = _Policies.Where(p => p.pid == pid).FirstOrDefault();
        if (result != null)
            return result;
        else
            return policy;
    }

    public List<Policy> UpdatePolicy(Policy policy)
    {
        int i = _Policies.FindIndex(p => p.pid == policy.pid);
        if (i >= 0)
        {
            _Policies[i].pname = policy.pname;
            _Policies[i].ptype = policy.ptype;
            _Policies[i].pgrade = policy.pgrade;
            _Policies[i].pstatus = policy.pstatus;
            _Policies[i].pCoverage = policy.pCoverage;
            _Policies[i].pdesc = policy.pdesc;
            _Policies[i].pdesc_short = policy.pdesc_short;
            _Policies[i].pPremium = policy.pPremium;
            _Policies[i].gender = policy.gender;
            _Policies[i].insurer = policy.insurer;
            _Policies[i].members = policy.members;
            _Policies[i].ageGroup = policy.ageGroup;
        }
        return _Policies;
    }
}