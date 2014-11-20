module Interface

type CreatureType =
    | Puppy
    | Kitten
    | Hedgehog
    | Bearcub
    | Piglet
    | Bat
    | Balloon

type DaylightType =
    | Morning
    | Noon
    | Evening
    | Night

type luminary = bool

type IDaylight =
    abstract member Current : DaylightType

type ILuminary = 
    abstract member IsShining : bool

type IWind =
    abstract member Speed : int

type Creature(creature: CreatureType) = 
    member x.CreatureType = creature

type ICourier =
    abstract member GiveBaby : Creature -> unit

type IMagic =
    abstract member CallDaemon : unit -> ICourier
    abstract member CallStork : unit -> ICourier