namespace AutoRegister;

sealed record AutoRegisteredClass(string ClassName,
                                  AutoRegistrationType RegistrationType,
                                  string[] Interfaces,
                                  object? ServiceKey);