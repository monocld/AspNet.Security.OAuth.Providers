# Integrating the MonoCloud Provider

1. Sign up for a [MonoCloud](https://docs.monocloud.com/api/auth/signin?register=true) account and create a tenant. Proceed to step 2 if you already have a tenant.
2. Navigate to the `Clients` section in the MonoCloud Dashboard and click on `Add Client`. Then follow the prompts to create a Web Application client.
3. Copy the `Tenant Domain` and `Client Id` from the General Settings section, `Client Secret` from the Secrets section (a default client secret will be generated when you create a web client).
4. Update the `Callback Uri` and `Sign-out Uri` in the Url section.
5. Select `openid`, `profile`, and `email` from the `Identity Scopes` within the Allowed Scopes section.
6. Click `Save Changes`.

 > Note: Tenant Domain copied from the Client's general settings section will be the full URL. The URL format is https://&lt;domain&gt;.&lt;region&gt;.monocloud.com.

## Example

```csharp
services.AddAuthentication(options => /* Auth configuration */)
        .AddMonoCloud(options =>
        {
            options.ClientId = "my-client-id";
            options.ClientSecret = "my-client-secret";
            options.DomainName = "domain";
            options.Region = "region";
        });
```

## Required Additional Settings

| Property Name | Property Type | Description                  | Default Value |
|:--------------|:--|:-----------------------------|:--|
| `DomainName`  | `string?` | The MonoCloud tenant domain. | `null` |
| `Region`      | `string?` | The MonoCloud tenant region. | `null` |

## Optional Settings

_None._
