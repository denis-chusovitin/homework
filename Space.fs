//Chusovitin Denis Copyrights (c) 2014
//

[<AbstractClass>]
type Named(name:string) =
    member this.Name = name
    abstract member SetName : string -> unit

let rec ifElemInList list value = 
    match list with
    | [] -> false
    | hd :: tl -> if (hd = value) then true
                  else ifElemInList tl value

type Satellite(name:string, mass:int, speed:int) =
    let mutable speed = speed

    member this.Name = name

type Planet(name:string, star:StarSystem, satellites:Satellite list) =
    let mutable satellites = satellites
    let mutable exist = true

    member this.Star = star
    member this.Destroy() =
        exist <- false
        let rec pl (satellites:Satellite list)  =
            match satellites with 
            | [] -> []
            | hd :: tl -> new Planet(hd.Name, star, []) :: pl tl

        star.AddPlanets (pl satellites)
        
    member this.AddSatellite(x:Satellite) = satellites <- x :: satellites

and StarSystem(name:string, planets:Planet list) =
    let mutable planets = planets

    member this.Planets = planets
    member this.AddPlanets(x:Planet list) = planets <- x @ planets

type SpaceShip(name:string, fuel:int, strength:int, star:StarSystem, planet:Planet) =
    inherit Named(name)
    let mutable name = name
    let mutable fuel = 100
    let mutable strength = 100
    let mutable exist = true
    let mutable star = star
    let mutable planet = planet

    member this.Destroy() = exist <- false
    member this.Damage(x:int) =
         strength <- strength - x
         if strength < 0 then this.Destroy() 
    member this.Repair(x:int) = strength <- strength + x
    member this.Pour(x:int) = fuel <- fuel + x
    member this.MoveToPlanet(x:Planet) = 
        if (fuel > 1) && (ifElemInList star.Planets x) then 
            fuel <- fuel - 1
            planet <- x
    member this.MoveToStarSystem(x:StarSystem) =
        if fuel > 10 then
            fuel <- fuel - 10
            star <- x 
          
    override this.SetName newname = name <- newname


type DeathStar(star:StarSystem, planet:Planet) = 
    inherit SpaceShip("DeathStar", 1000, 1000, star, planet)
    
    member this.BlowUp(x:Planet) = x.Destroy()
  
type Asteroid(size:int, mass:int, speed:int) = 
    let mutable exist = true
    let mutable speed = speed

    member this.Speed = speed
    member this.SmashWithAsteroid(ast:Asteroid) = 
        let x = speed
        speed <- ast.Speed
        ast.Speed = x
    member this.SmashWithSpaceShip(ship:SpaceShip) = ship.Damage(speed*mass)


let Sun = new StarSystem("SunSystem", [])

let Moon = new Satellite("Moon", 1000, 1000)

let Jupiter = new Planet("Jupiter", Sun, [])
let Earth = new Planet("Earth", Sun, [Moon]) 
Sun.AddPlanets [Earth]

let ast = new Asteroid(100, 10, 10)

let ship = new SpaceShip("Barsik", 10, 100, Sun, Earth)
let bigship = new DeathStar(Sun, Earth)

bigship.BlowUp Earth

ast.SmashWithSpaceShip ship

ship.MoveToPlanet Jupiter


