EXTERNAL showWatch()

Hey! If it isn't Nicholas! What can I do for you, pal? #charName: Ruther

* [(show ticket)] 
    I'm here for this. I dropped this off a few days ago? #charName: Nicholas
    ->give_ticket
    
* [Just wanted to have a look around.]
    Well then, take your time. #charName: Ruther

== give_ticket
So soon? I thought it might be a while til' you had the money. #charName: Ruther
You do have the money you owe, right? Your total including fees and interest is $63.
* Yes, of course[(give him the money)], here it is. #charName: Nicholas
    Ruther counts the notes carefully.
    Perfect. Let me get that watch for you. #charName: Ruther
    // call fn
    ~ showWatch()
    ->DONE
* No, not right now. #charName: Nicholas
    Well, you remember how this works right? #charName: Ruther
    I loaned you $50 for your watch, and to get it back, you have to repay the loan plus interest and fees. #charName: Ruther
    Come back with $63, and you can get it back right away, ok?
->DONE