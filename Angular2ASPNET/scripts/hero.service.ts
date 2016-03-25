import {HEROES} from "./mock-heroes";
import {IHero} from "./hero";
import {Injectable} from "angular2/core";

@Injectable()
export class HeroService {
    getHero(id: number) {
        return Promise.resolve(HEROES).then(
            heroes => heroes.filter(hero => hero.id === id)[0]
        );
    }

    getHeroes() {
        return Promise.resolve(HEROES);
    }

    getHeroesSlowly() {
        return new Promise<IHero[]>(resolve =>
            setTimeout(() => resolve(HEROES), 2000)
        );
    }
}