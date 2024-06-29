namespace Ninjato.Models;

public class SiteConfiguration
{
    public string Name { get;set; } = "Ninjato Blog";
    public List<string> Authors { get; set; } = new() {"Anonymous" };

    public string Copyright { get; set; } = "Copyright 2024 Ninjato.  All rights reserved.";
}