namespace AutoRegister;

sealed record AutoRegisteredClass(string ClassName,
                                  string ClassNamespace,
                                  AutoRegistrationType RegistrationType,
                                  string[] Interfaces,
                                  object? ServiceKey);