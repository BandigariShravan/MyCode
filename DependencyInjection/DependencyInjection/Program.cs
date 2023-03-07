// See https://aka.ms/new-console-template for more information
using DependencyInjection;

Injector injector=new Injector();
Client cli = injector.ResolveClient();
cli.UseService();