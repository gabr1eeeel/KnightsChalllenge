export interface Knight {
    id?: string;
    name: string;
    nickname: string;
    birthday: string;
    weapons: Weapon[];
    attributes: Attributes;
    keyAttribute: string;
    isHero: boolean;
    weaponCount?: number;  
    attack?: number;       
    experience?: number;   
    age?: number;
}

export interface Weapon {
    name: string;
    mod: number;
    attr: string;
    equipped: boolean;
}

export interface Attributes {
    strength: number;
    dexterity: number;
    constitution: number;
    intelligence: number;
    wisdom: number;
    charisma: number;
}