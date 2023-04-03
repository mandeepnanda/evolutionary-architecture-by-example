namespace SuperSimpleArchitecture.Fitnet.IntegrationTests.Passes.MarkPassAsExpired;

using Fitnet.Passes;
using RegisterPass;
using Common.TestEngine;
using Common.TestEngine.Configuration;
using SuperSimpleArchitecture.Fitnet.Passes.RegisterPass;

public sealed class MarkPassAsExpiredTests : IClassFixture<WebApplicationFactory<Program>>, IClassFixture<DatabaseContainer>
{
    private static readonly StringContent EmptyContent = new(string.Empty);
    
    private readonly HttpClient _applicationHttpClient;

    public MarkPassAsExpiredTests(WebApplicationFactory<Program> applicationInMemoryFactory,
        DatabaseContainer database) =>
        _applicationHttpClient = applicationInMemoryFactory
            .WithContainerDatabaseConfigured(database.ConnectionString!)
            .CreateClient();

    [Fact]
    public async Task Given_valid_mark_pass_as_expired_request_Then_should_return_no_content()
    {
        // Arrange
        var registeredPassId = await RegisterPass();
        var url = BuildUrl(registeredPassId);

        // Act
        var markAsExpiredResponse = await _applicationHttpClient.PatchAsJsonAsync(url, EmptyContent);

        // Assert
        markAsExpiredResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task Given_mark_pass_as_expired_request_with_not_existing_id_Then_should_return_not_found()
    {
        // Arrange
        var notExistingId = Guid.NewGuid();
        var url = BuildUrl(notExistingId);

        // Act
        var markAsExpiredResponse = await _applicationHttpClient.PatchAsJsonAsync(url, EmptyContent);

        // Assert
        markAsExpiredResponse.Should().HaveStatusCode(HttpStatusCode.NotFound);
    }

    private async Task<Guid> RegisterPass()
    {
        RegisterPassRequest registerPassRequest = new RegisterPassRequestFaker();
        var registerPassResponse = await _applicationHttpClient.PostAsJsonAsync(PassesApiPaths.Register, registerPassRequest);
        var registeredPassId = await registerPassResponse.Content.ReadFromJsonAsync<Guid>();

        return registeredPassId;
    }
    
    private static string BuildUrl(Guid id) => PassesApiPaths.MarkPassAsExpired.Replace("{id}", id.ToString());
}
