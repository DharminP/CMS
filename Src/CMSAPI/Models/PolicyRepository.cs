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
            pstatus = "A"
        });
        _Policies.Add(new Policy
        {
            pid = 2,
            pname = "GPAPolicy1",
            ptype = "GPA",
            pgrade = 11,
            pstatus = "A"
        });
        _Policies.Add(new Policy
        {
            pid = 3,
            pname = "GTLPolicy1",
            ptype = "GTL",
            pgrade = 10,
            pstatus = "A"
        });
        _Policies.Add(new Policy
        {
            pid = 4,
            pname = "GTLPolicy2",
            ptype = "GTL",
            pgrade = 1,
            pstatus = "A"
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
        return _Policies;
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
        }
        return _Policies;
    }
}