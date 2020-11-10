﻿using Managing_Adults.Models;

namespace Managing_Adults.Data {
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}