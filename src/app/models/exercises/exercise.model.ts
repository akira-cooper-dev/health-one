import { BaseEntity } from "../core/entity.model"

export interface Exercise extends BaseEntity {
    name: string,
    type: string,
    muscle: string,
    equipment: string,
    difficulty: string,
    instructions: string
}