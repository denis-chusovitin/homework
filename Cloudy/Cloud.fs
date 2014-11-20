module Cloud

open Interface

type Daylight(day) =
    interface IDaylight with
        member x.Current = day

type Luminary(lum) = 
    interface ILuminary with
        member x.IsShining = lum

//type Wind(wind) =
   // interface IWind with

type Cloud(daylight : IDaylight, luminary: ILuminary, wind: IWind, magic: IMagic) =
    member x.InternalCreate(isDaemon, creatureType) =
        let creature = new Creature(creatureType)
        if isDaemon then magic.CallDaemon().GiveBaby(creature)
            else magic.CallStork().GiveBaby(creature)
        creature
    
    member x.Create() =
        match (luminary.IsShining, wind.Speed, daylight.Current) with
        | (true, y, Morning) when y >= 0 && y <= 3 -> x.InternalCreate(false, Kitten)
        | (true, y, Noon) when y >= 4 && y <= 5 -> x.InternalCreate(false, Puppy)
        | (true, y, Evening) when y >= 3 && y <= 8 -> x.InternalCreate(true, Hedgehog)
        | (false, y, Night)  when y >= 4 && y <= 7 -> x.InternalCreate(false, Bearcub)
        | (false, y, day)  when y >= 0 && y <= 10 && ((day = Noon) || (day = Evening)) -> x.InternalCreate(false, Piglet)
        | (true, y, day)  when y >= 8 && y <= 10 && ((day = Morning) || (day = Night))-> x.InternalCreate(true, Bat)
        | _ -> x.InternalCreate(true, Balloon)
