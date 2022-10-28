using CMSAPI.Models;

public interface IPolicyRepository
{
    List<Policy> GetPolicies();
    Policy GetPolicyById(int pid);
    List<Policy> CreatePolicy(Policy policy);
    List<Policy> UpdatePolicy(Policy policy);
    List<Policy> DeletePolicy(int pid);
}