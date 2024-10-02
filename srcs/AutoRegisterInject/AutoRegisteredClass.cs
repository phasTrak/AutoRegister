namespace AutoRegisterInject;

record AutoRegisteredClass(string ClassName,
                           AutoRegistrationType RegistrationType,
                           string[] Interfaces,
                           string? ServiceKey);