using Microsoft.AspNetCore.Identity;
using Ticketing_System.Models;

public class TeamMemberService : ITeamMemberService
{
    private readonly ITeamMemberRepository _repo;
    private readonly UserManager<User> _userManager;

    public TeamMemberService(ITeamMemberRepository repo, UserManager<User> userManager)
    {
        _repo = repo;
        _userManager = userManager;
    }

    public Task<List<TeamMember>> GetAllAsync() => _repo.GetAllAsync();
    public Task<TeamMember> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public async Task AddAsync(TeamMember member)
{
    // 1️⃣ Ajoute le TeamMember via le repository
    await _repo.AddAsync(member);

    // 2️⃣ Récupère le user avec l'ID
    var user = await _userManager.FindByIdAsync(member.UserId);

    // 3️⃣ Ajoute le rôle uniquement si le user existe
    if (user != null)
    {
        await _userManager.AddToRoleAsync(user, "SupportAgent");
    }
}


    public Task UpdateAsync(TeamMember member) => _repo.UpdateAsync(member);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}
