export class GeneratePasswordDto {
    public IncludeNumbers: boolean;
    public IncludeLowerCaseCharacters: boolean;
    public IncludeUpperCaseCharacters: boolean;
    public IncludeSpecialCharacters: boolean;
    public Length: number;

    constructor() {
        this.IncludeNumbers = true;
        this.IncludeLowerCaseCharacters = true;
        this.IncludeUpperCaseCharacters = true;
        this.IncludeSpecialCharacters = true;
        this.Length = 6;
    }
}