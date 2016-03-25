import {Component, OnInit} from "angular2/core";
import {Router} from "angular2/router";
import {IHero} from "./hero";
import {HeroService} from "./hero.service";

@Component({
    selector: "my-heroes",
    templateUrl: "app/heroes.component.html",
    styleUrls: ["app/heroes.component.css"]
})

export class HeroListComponent implements OnInit {
    constructor(
        private _heroService: HeroService,
        private _router: Router) { }

    ngOnInit() {
        this.getHeroes();
    }

    title = "Tour of Heroes";
    heroes: IHero[];
    selectedHero: IHero;

    onSelect(hero: IHero) {
        this.selectedHero = hero;
    }

    getHeroes() {
        this._heroService.getHeroes().then(heroes => this.heroes = heroes);
    }

    gotoDetail() {
        this._router.navigate(["HeroDetail", { id: this.selectedHero.id }]);
    }
}