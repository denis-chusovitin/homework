module Test

open Cloud
open Interface
open NSubstitute
open FsCheck
open NUnit.Framework

let test isDaemon creatureType (isShining: bool) (speed: int) (day: DaylightType) =
    let magic = Substitute.For<IMagic>()
    let daylight = Substitute.For<IDaylight>()
    let luminary = Substitute.For<ILuminary>()
    let wind = Substitute.For<IWind>()
    let courier = Substitute.For<ICourier>()

    daylight.Current.Returns(day) |> ignore
    luminary.IsShining.Returns(isShining) |> ignore
    wind.Speed.Returns(speed) |> ignore
    magic.CallDaemon().Returns(courier) |> ignore
    magic.CallStork().Returns(courier) |> ignore

    let cloud = new Cloud(daylight, luminary, wind, magic)

    cloud.Create() |> ignore

    if isDaemon then magic.Received().CallDaemon() |> ignore
    else  magic.Received().CallStork() |> ignore
    courier.Received().GiveBaby(Arg.Is<Creature>(fun (x: Creature) -> creatureType = x.CreatureType))

[<Test>]
let test'() =
    let magic = Substitute.For<IMagic>()
    let daylight = Substitute.For<IDaylight>()
    let luminary = Substitute.For<ILuminary>()
    let wind = Substitute.For<IWind>()
    let courier = Substitute.For<ICourier>()
    let cloud = new Cloud(daylight, luminary, wind, magic)

    daylight.Current.Returns(DaylightType.Morning) |> ignore
    luminary.IsShining.Returns(true) |> ignore
    wind.Speed.Returns(9) |> ignore
    magic.CallDaemon().Returns(courier) |> ignore

    cloud.Create() |> ignore

    Received.InOrder(fun () ->
        magic.CallDaemon() |> ignore 
        courier.GiveBaby(Arg.Any<Creature>()) |> ignore)
    
type Generator1 = 
    static member bool() = Arb.fromGen <| Gen.constant true
    static member int() = Arb.fromGen <| Gen.choose(0, 3)
    static member DaylightType() = Arb.fromGen <| Gen.constant Morning   

[<Test>]      
let test1() =
    Arb.register<Generator1>() |> ignore
    FsCheck.Check.Quick (test false Kitten)

type Generator2 = 
    static member bool() = Arb.fromGen <| Gen.constant true
    static member int() = Arb.fromGen <| Gen.choose(4, 5)
    static member DaylightType() = Arb.fromGen <| Gen.constant Noon  

[<Test>]      
let test2() =
    Arb.register<Generator2>() |> ignore
    FsCheck.Check.Quick (test false Puppy)

type Generator3 = 
    static member bool() = Arb.fromGen <| Gen.constant true
    static member int() = Arb.fromGen <| Gen.choose(3, 8)
    static member DaylightType() = Arb.fromGen <| Gen.constant Evening

[<Test>]      
let test3() =
    Arb.register<Generator3>() |> ignore
    FsCheck.Check.Quick (test true Hedgehog)

type Generator4 = 
    static member bool() = Arb.fromGen <| Gen.constant false
    static member int() = Arb.fromGen <| Gen.choose(4, 7)
    static member DaylightType() = Arb.fromGen <| Gen.constant Night

[<Test>]      
let test4() =
    Arb.register<Generator4>() |> ignore
    FsCheck.Check.Quick (test false Bearcub)

type Generator5 = 
    static member bool() = Arb.fromGen <| Gen.constant false
    static member int() = Arb.fromGen <| Gen.choose(0, 10)
    static member DaylightType() = Arb.fromGen <| Gen.oneof [ gen { return Noon }; gen { return Evening } ] 

[<Test>]      
let test5() =
    Arb.register<Generator5>() |> ignore
    FsCheck.Check.Quick (test false Piglet)

type Generator6 = 
    static member bool() = Arb.fromGen <| Gen.constant true
    static member int() = Arb.fromGen <| Gen.choose(8, 10)
    static member DaylightType() = Arb.fromGen <| Gen.oneof [ gen { return Morning }; gen { return Night } ] 

[<Test>]      
let test6() =
    Arb.register<Generator6>() |> ignore
    FsCheck.Check.Quick (test true Bat)

type Generator7 = 
    static member bool() = Arb.fromGen <| Gen.constant false
    static member int() = Arb.fromGen <| Gen.choose(3, 6)
    static member DaylightType() = Arb.fromGen <| Gen.constant Morning

[<Test>]
let test7() =
    Arb.register<Generator7>() |> ignore
    FsCheck.Check.Quick (test true Balloon)