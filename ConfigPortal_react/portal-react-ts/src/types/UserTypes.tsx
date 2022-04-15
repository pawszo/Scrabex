export type User = {
    Id: number,
    UserTitle: string,
    CreatedAt: Date,
    CountryCode: string,
    AccessLevel: number,
    Details: UserDetail
};

export type UserData = {
    User: User,
    Token: string
}

export type UserDetail = {
    Id: number,
    UserId: number,
    Login: string,
    Email: string,
    Password: Int8Array,
    ForgotPassword: boolean,
    LastUpdate: Date
};

export type AuthenticationResponse = {
    id: number,
    login: string,
    token: string
};

export type LoginDto = {
    login: string,
    password: string,
    forgotPassword: boolean
};

export type RegisterDto = {
    login: string,
    password: string,
    email: string,
    consent: boolean,
    title: string,
    countryCode: string
};