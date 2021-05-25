import { User } from "../models/User";

export interface AuthResponseDto{
    isAuthSuccessful: boolean;
    errorMessage: string;
    token:string;
    user: User;
}