/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

namespace AspNet.Security.OAuth.MonoCloud;

public static class MonoCloudPostConfigureOptionsTests
{
    [Fact]
    public static void PostConfigure_Configures_Valid_Endpoints()
    {
        // Arrange
        string name = "MonoCloud";
        var target = new MonoCloudPostConfigureOptions();

        var options = new MonoCloudAuthenticationOptions()
        {
            DomainName = "test",
            Region = "us"
        };

        // Act
        target.PostConfigure(name, options);

        // Assert
        options.AuthorizationEndpoint.ShouldStartWith("https://test.us.monocloud.com/connect");
        Uri.TryCreate(options.AuthorizationEndpoint, UriKind.Absolute, out _).ShouldBeTrue();

        options.TokenEndpoint.ShouldStartWith("https://test.us.monocloud.com/connect");
        Uri.TryCreate(options.TokenEndpoint, UriKind.Absolute, out _).ShouldBeTrue();

        options.UserInformationEndpoint.ShouldStartWith("https://test.us.monocloud.com/connect");
        Uri.TryCreate(options.UserInformationEndpoint, UriKind.Absolute, out _).ShouldBeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public static void PostConfigure_Throws_If_Domain_Is_Invalid(string value)
    {
        // Arrange
        string name = "MonoCloud";
        var target = new MonoCloudPostConfigureOptions();

        var options = new MonoCloudAuthenticationOptions()
        {
            DomainName = value,
        };

        // Act and Assert
        Assert.Throws<ArgumentException>("options", () => target.PostConfigure(name, options));
    }
}
