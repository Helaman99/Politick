var re=(d,s,i)=>{if(!s.has(d))throw TypeError("Cannot "+i)};var K=(d,s,i)=>(re(d,s,"read from private field"),i?i.call(d):s.get(d)),P=(d,s,i)=>{if(s.has(d))throw TypeError("Cannot add the same private member more than once");s instanceof WeakSet?s.add(d):s.set(d,i)};import{h as ue,a as c,o as j,j as V,w as a,b as e,e as h,t as ae,n as oe,d as S,r as m,k as pe,c as te,g as y,l as de,F as ce,u as _,m as ge,q as he,s as Z,x as me,y as be,z as I,A as J}from"./index-eab5ed3f.js";import{c as w,t as Q,r as L,o as X}from"./roomController-d1eac660.js";import{p as ee}from"./PlayerCard-5c0fbc98.js";const fe={props:["messageClass","text"]};function ye(d,s,i,u,f,o){const p=c("v-card-text"),n=c("v-card");return j(),V(n,{class:oe(i.messageClass),elevation:"0"},{default:a(()=>[e(p,null,{default:a(()=>[h(ae(i.text),1)]),_:1})]),_:1},8,["class"])}const ke=ue(fe,[["render",ye],["__scopeId","data-v-112a8a8f"]]),ve=S({__name:"ChatFooter",emits:["send"],setup(d,{emit:s}){const i=m(""),u=()=>{s("send",i.value),i.value=""};return(f,o)=>{const p=c("v-btn"),n=c("v-textarea"),g=c("v-footer");return j(),V(g,{app:""},{default:a(()=>[e(n,{modelValue:i.value,"onUpdate:modelValue":o[0]||(o[0]=M=>i.value=M),placeholder:"Message","auto-grow":"",autocomplete:"",rows:"1",variant:"outlined"},{append:a(()=>[e(p,{onClick:u},{default:a(()=>[h("Send")]),_:1})]),_:1},8,["modelValue"])]),_:1})}}}),_e={class:"chat-header"},we=y("h1",{id:"countdown"},null,-1),je=S({__name:"ChatHeader",emits:["timerEnd"],setup(d,{expose:s,emit:i}){const u=m(0);function f(o){const p=document.getElementById("countdown");if(p&&o>0){let n=59;o--,u.value=o;const g=setInterval(()=>{o===0&&n===-1?(clearInterval(g),i("timerEnd")):n===-1?(o--,u.value=o,n=59,p.textContent=o+":"+n,n--):n<10?(p.textContent=o+":0"+n,n--):(p.textContent=o+":"+n,n--)},1e3)}}return pe(()=>{f(8)}),s({startTimer:f,minutesLeft:u}),(o,p)=>{const n=c("v-app-bar-title"),g=c("v-app-bar");return j(),te("div",_e,[e(g,{elevation:"3",height:"75",color:"white"},{default:a(()=>[e(n,null,{default:a(()=>[we]),_:1})]),_:1})])}}});var T;class ie{static filterMessage(s){const i=s.split(" ");let u=0;for(let o=0;o<i.length;o++)if(console.log(i[o].replace(/[^a-zA-Z]/g,"").toLowerCase()),K(this,T).includes(i[o].replace(/[^a-zA-Z]/g,"").toLowerCase())){if(u++,u==5)return{message:"DETECTION LIMIT MET",detections:5};const p=i[o].split("").length;let n="";for(let g=0;g<p;g++)n+="_";i[o]=n}return{message:i.join(" "),detections:u}}}T=new WeakMap,P(ie,T,["1 man 1 jar","1m1j1","1man1jar","2 girls 1 cup","2g1c","2girls1cup","acrotomophile","acrotomophilia","alabama hot pocket","alabama tuna melt","alaskan pipeline","algophile","algophilia","anal","anal assassin","anal astronaut","anilingus","anus","ape shit","ape-shit","apeshit","apotemnophile","apotemnophilia","arse","arse bandit","arsehole","ass","ass bandit","asshole","auto erotic","autoerotic","babeland","baby batter","baby gravy","baby juice","ball batter","ball gag","ball gravy","ball kicking","ball licking","ball sack","ball sucking","ball-gag","ball-kicking","ball-licking","ball-sucking","ballcuzi","ballgag","bang bros","bang bus","bangbros","bangbus","bareback","barely legal","bastard","bastinado","batty boi","batty boy","battyboi","battyboy","bdsm","bean flicker","bean queen","bean-flicker","beaner","beaners","beanflicker","beastiality","beaver cleaver","beaver lips","beestiality","bellend","bellesa","bestiality","bicon","big boobs","big breasts","big cock","big knockers","big tits","birdlock","bitch","bitches","black cock","bloody","blow job","blow your load","blow-job","blowjob","blue waffle","bluewaffle","blumpkin","bollocks","bone smuggler","bone-smuggler","boner","bonesmuggler","boob","booty buffer","booty call","booty-buffer","boston george","breasts","brown piper","brown shower","brown showers","brown-piper","brownie king","brownie queen","brownpiper","buddha head","buddha-head","buddhahead","bufter","bufty","bugger","bukkake","bull shit","bull-shit","bulldyke","bullet vibe","bullet vibrator","bullshit","bum boy","bum chum","bum driller","bum pilot","bum pirate","bum rider","bum robber","bum rustler","bum-boy","bum-chum","bum-driller","bum-pirate","bum-robber","bumboy","bumchum","bumdriller","bumhole engineer","bumrider","bumrobber","butt boy","butt pilot","butt pirate","butt rider","butt robber","butt rustler","butt-boy","butt-pirate","butt-robber","buttboy","butthole engineer","buttrider","buttrobber","camel jockey","camel jockies","camel toe","cameljockey","cameljockies","canadian porch swing","carpet muncher","carpetmuncher","cheese eating surrender monkey","cheese-eating surrender monkey","chi chi man","chi-chi man","chicken queen","china man","china men","chinaman","chinamen","ching chong","ching-chong","chink","chinks","chinky","chocolate rosebud","chocolate rosebuds","cholerophile","cholerophilia","christ","cialis","circle-jerk","circlejerk","cishet","cissie","cissy","claustrophile","claustrophilia","cleveland accordion","cleveland hot waffle","cleveland steamer","clit","clitoris","clover clamp","clover clamps","clunge","cluster fuck","cluster-fuck","clusterfuck","cock","cockpipe cosmonaut","cockstruction worker","coimetrophile","coimetrophilia","collared","collaring","coon","coons","coprolagnia","coprophile","coprophilia","cornhole","crafty butcher","crap","cream-pie","creampie","cum","cum shot","cum shots","cumming","cumshot","cumshots","cunnilingus","cunt","cunt boy","cunt-boy","cuntboy","cunts","curry muncher","curry-muncher","currymuncher","damn","darkey","darkie","darkies","darky","date rape","daterape","ddlg","deep throat","deep-throat","deepthroat","dendrophile","dendrophilia","dick","dick girl","dick-girl","dickgirl","dildo","dildos","dingleberries","dingleberry","dipsea","dirty pillows","dirty sanchez","dishabiliophile","dishabiliophilia","dog shit","dog style","dog-shit","doggie style","doggie-style","doggiestyle","doggy style","doggy-style","doggystyle","dogshit","dolcett","domination","dominatrix","domme","dommes","donkey punch","donut muncher","donut puncher","doon coon","dooncoon","double penetration","dp action","dry hump","dune coon","dune-coon","dutch rudder","dyke","dystychiphile","dystychiphilia","edge play","edgeplay","ejaculate","ejaculated","ejaculating","ejaculation","electro-play","electroplay","emetophile","emetophilia","enby","eskimo trebuchet","eye-tie","eyetie","fag","fag bomb","fag-bomb","fagbomb","faggot","fagot","felch","felching","fellating","fellatio","female squirting","figging","finger bang","fingerbang","fingerbanging","fingered","fingering","finocchio","finoccio","finochio","fisted","fisting","foot job","foot-job","footjob","french rudder","frog eater","frog-eater","frogeater","frolic me","frolicme","frottage","frotting","fuck","fuck-wit","fucken","fucker","fuckers","fuckhead","fuckheads","fuckin","fucking","fucks","fucktard","fucktards","fuckwad","fuckwads","fuckwhit","fuckwit","fuckwits","fudge packer","fudge-packer","fudgepacker","futanari","g-spot","gang bang","gangbang","gay sex","gaysian","genitals","genitorture","gerontophile","gerontophilia","giant cock","gin jockey","gin jocky","girl on top","go-kun","goatcx","goatse","god damn","god damned","god-damn","god-damned","goddamn","goddamned","gokkun","golden shower","golden showers","golliwog","gollywog","gook","gook-eye","gookie","gooks","gooky","goregasm","gray queen","greaseball","grey queen","grope","group sex","gym bunny","gymbunny","hadji","haji","hajji","hand job","hand-job","handjob","heimie","hell","hermie","hickory switch","hippophile","hippophilia","homoerotic","honkey","honkeys","honkies","honky","horny","horse shit","horse-shit","horseshit","hot carl","hot richard","huge cock","humping","hymie","impact play","impact-play","incest","intercourse","jack off","jack-off","jail bait","jailbait","jap","jelly donut","jerk mate","jerk off","jerk-off","jerkmate","jesus","jesus christ","jigaboo","jiggerboo","jizz","juggs","jungle bunny","junglebunny","kennebunkport surprise","kentucky klondike","kentucky tractor puller","kike","kinbaku","kitty puncher","kitty-puncher","kittypuncher","knobbing","kraut","krauts","kunt","kunts","kynophile","kynophilia","lady boy","lady-boy","ladyboy","leather restraint","leather straight jacket","lemon party","lemonparty","leningrad steamer","lesbo","leso","lezzie","lezzies","light in the fedora","light in the loafers","light in the pants","limp wristed","limp-wristed","literotica","lovemaking","male squirting","male-squirting","massive cock","masterb8","masterbate","masturb8","masturbate","masturbating","masturbation","mayonnaise monkey","mayonnaise monkies","mdlb","meat masseuse","meat spin","meatspin","menage a trois","menage-a-trois","menages a trois","menages-a-trois","menophile","menophilia","mexican pancake","milwaukee blizzard","missionary position","mississippi birdbath","mound of venus","mr hands","mr. hands","mrhands","muff diver","muff diver","muff diving","muff-diver","muffdiver","muffdiver","muffdiving","muscle mary","mvtube","nambla","necrophile","necrophilia","negro","neo nazi","neo-nazi","neonazi","nig nog","nigerian hurricane","nigga","nigger","niggs","nignog","nimpho","nimphomania","nimphomaniac","nipple","nipple clamp","nipple clamps","nipples","nude","nudity","nutten","nympho","nymphomania","nymphomaniac","octopussy","oklahomo","omorashi","one cup two girls","one jar one man","one man one jar","only fans","onlyfans","orgasm","orgasmic","orgasms","paedo bear","paedobear","paedophile","paedophilia","pain slut","painslut","paki","panamanian petting zoo","pansy","panties","parthenophile","parthenophilia","pedo bear","pedobear","pedophile","pedophilia","pegging","penis","peter puffer","peter-puffer","peterpuffer","petrol sniffer","petrol-sniffer","petrolsniffer","phagophile","phagophilia","piece of shit","pieces of shit","pikey","pikeys","piss off","piss pig","piss pig","pissed off","pissing","pisspig","pisspig","playboy","pleasure chest","pnigerophile","pnigerophilia","pnigophile","pnigophilia","poinephile","poinephilia","pony boy","pony girl","pony-boy","pony-girl","pony-play","ponyboy","ponygirl","ponyplay","poof","poon","poontang","poop chute","poopchute","porn","porn hub","pornhub","porno","pornographic","pornography","pornos","potato queen","prince albert piercing","proctophile","proctophilia","pubes","punani","punany","pussy","pussy puncher","pussy-puncher","pussypuncher","queaf","queef","quim","rag head","rag heads","raghead","ragheads","raging boner","ramen yarmulke","rape","raping","rapist","rectum","retard","retarded","reverse cowgirl","rhabdophile","rhabdophilia","rhypophile","rhypophilia","rice queen","rimjob","rimming","ring raider","ringraider","rusty trombone","sand nigger","sand-nigger","sandnigger","santorum","scatophile","scatophilia","schlong","scissoring","semen","seplophile","seplophilia","sex","shaved beaver","shaved pussy","she male","she-male","sheep shagger","sheepshagger","shemale","shibari","shit","shit head","shithead","shitty","shlong","shota","shrimping","sissy","skeet","skittle harvest","skittles harvest","slant eye","slant-eye","slanteye","snatch","snowballing","sod off","sodding","sodomise","sodomist","sodomize","sodomy","spastic","spearchucker","spic","spick","spicks","spics","spicy gringo","splooge","splooge moose","spooge","spunk","strap on","strap-on","strap-on","strapon","strappado","stupid","stoopid","suastika","svastika","swamp guinea","swamp-guinea","swastika","switch hitter","t-girl","taphephile","taphephilia","tea bagged","tea bagging","tea-bagged","tea-bagging","tgirl","thanatophile","thanatophilia","threesome","throating","throbbing boner","throbbing cock","thumbzilla","timber nigger","timber-nigger","timbernigger","tits","titties","titty","topless","tosser","towel head","towel-head","towelhead","trannie","tranny","transbian","traumatophile","traumatophilia","tribadism","tribbing","tub girl","tubgirl","twat","twink","two girls one cup","urethra play","urophile","urophilia","vagina","venus mound","viagra","vibrator","violet wand","vorarephile","vorarephilia","voyeurweb","wagon burner","wagon-burner","wank","wanker","wax play","wax-play","wet back","wet dream","wet-back","wetback","whigger","white power","white-power","whitepower","whore","wigga","wigger","wiitwd","wog","wogs","wolfbagging","worldsex","wrapping men","wrinkled starfish","xhamster","xnxx","xtube","xvideos","xxx","xyrophile","xyrophilia","yellow shower","yellow showers","zipper head","zipper-head","zipperhead","zippo cat","zippo-cat","zippocat","zoophile","zoophilia"]);const xe={class:"chat"},Ce={class:"messages"},ze=y("h3",null,"You:",-1),Ve=y("h1",null,"VS",-1),Te=y("h3",null,"Opponent:",-1),Ie=S({__name:"ChatView",setup(d){var O,U,H,N,R;const s=m(!0);setTimeout(()=>{s.value=!1},4e3);const i=m([]),u=m(document.querySelector("html"));let f="";const o=w.value;let p=m(!1);console.log("You: "+((O=Q.value)==null?void 0:O.ChatRoomId)),console.log("Opponent: "+((U=Q.value)==null?void 0:U.ChatRoomId)),o==null||o.on("ReceiveMessage",r=>{r!=null&&r!=""&&r.trim()!==""&&r!=f&&(i.value.push({messageClass:"received-message",text:r}),u.value&&(u.value.scrollTop=u.value.scrollHeight+64))});let n=0;const g=m(!1);function M(r){if(r!=null&&r!=""&&r.trim()!==""){let t=ie.filterMessage(r);n+=t.detections,console.log(n),n<=4?(o==null||o.invoke("SendMessageToGroup",L.value,t.message),console.log(t.detections),i.value.push({messageClass:"sent-message",text:t.message}),u.value&&(u.value.scrollTop=u.value.scrollHeight+64),f=t.message):(he(),g.value=!0,setTimeout(()=>{var b;g.value=!1,n=0,(b=w.value)==null||b.stop(),Z.push("/dashboard")},4e3))}}(H=w.value)==null||H.on("PlayerDisconnected",()=>{p.value=!0});const x=m(!1),q=m();let A=!1;function ne(){A=!0,x.value=!0,me()}function le(){var r;if(be(1))o==null||o.invoke("AddTime",L.value,(r=I.value)==null?void 0:r.title);else{let t=document.getElementById("failed");t&&(t.innerHTML="<p style='color:red;'>Not enough coins!</p>")}}const C=m(!1);let B="";(N=w.value)==null||N.on("AddTime",r=>{B=r,C.value=!0,setTimeout(()=>{C.value=!1},3e3),x.value=!1,q.value.startTimer(2)});function E(){var r;A?J(5-n):J(5-q.value.minutesLeft-n),(r=w.value)==null||r.invoke("LeaveRoom",L.value),Z.push("/dashboard/topics")}const $=m(!1);return(R=w.value)==null||R.on("OpponentLeft",()=>{x.value=!1,$.value=!0}),(r,t)=>{const b=c("v-card"),k=c("v-dialog"),v=c("v-card-text"),z=c("v-btn"),D=c("v-card-actions"),Y=c("v-card-title"),se=c("v-app");return j(),V(se,null,{default:a(()=>[y("div",xe,[e(je,{onTimerEnd:t[0]||(t[0]=l=>ne()),ref_key:"chatHeader",ref:q},null,512),y("div",Ce,[(j(!0),te(ce,null,de(i.value,l=>(j(),V(ke,{key:l.messageClass,class:oe(l.messageClass),text:l.text},null,8,["class","text"]))),128))]),e(k,{class:"versus-dialog",modelValue:s.value,"onUpdate:modelValue":t[1]||(t[1]=l=>s.value=l),persistent:"",fullscreen:"",transition:"dialog-top-transition"},{default:a(()=>[e(b,{id:"versus-card"},{default:a(()=>{var l,F,G,W;return[y("div",null,[ze,e(ee,{"avatar-path":(l=_(I))==null?void 0:l.avatar,title:(F=_(I))==null?void 0:F.title,color:"white"},null,8,["avatar-path","title"])]),Ve,y("div",null,[Te,e(ee,{"avatar-path":(G=_(X))==null?void 0:G.Avatar,title:(W=_(X))==null?void 0:W.Title,color:"white"},null,8,["avatar-path","title"])])]}),_:1})]),_:1},8,["modelValue"]),e(k,{class:"game-over-dialog",modelValue:x.value,"onUpdate:modelValue":t[4]||(t[4]=l=>x.value=l),transition:"scale-transition",persistent:""},{default:a(()=>[e(b,{class:"game-over-card"},{default:a(()=>[e(v,null,{default:a(()=>[h(" You're all out of time! Would you like to spend 1 coin to gain another 2 minutes? ")]),_:1}),e(D,null,{default:a(()=>[e(z,{onClick:t[2]||(t[2]=l=>le())},{default:a(()=>[h("Yes")]),_:1}),e(z,{onClick:t[3]||(t[3]=l=>E())},{default:a(()=>[h("No")]),_:1})]),_:1}),e(v,{id:"failed"})]),_:1})]),_:1},8,["modelValue"]),e(k,{class:"opponent-left",modelValue:$.value,"onUpdate:modelValue":t[6]||(t[6]=l=>$.value=l),transition:"scale-transition",persistent:""},{default:a(()=>[e(b,{class:"opponent-left"},{default:a(()=>[e(Y,null,{default:a(()=>[h("The other player left the chat room.")]),_:1}),e(v,null,{default:a(()=>[h(" Time to find another opponent! ")]),_:1}),e(D,null,{default:a(()=>[e(z,{onClick:t[5]||(t[5]=l=>E())},{default:a(()=>[h("OK")]),_:1})]),_:1})]),_:1})]),_:1},8,["modelValue"]),e(k,{class:"time-added-dialog",modelValue:C.value,"onUpdate:modelValue":t[7]||(t[7]=l=>C.value=l)},{default:a(()=>[e(b,{id:"time-added-card"},{default:a(()=>[e(v,null,{default:a(()=>[h(ae(_(B))+" added 2 minutes to the time! ",1)]),_:1})]),_:1})]),_:1},8,["modelValue"]),e(k,{class:"disconnected-dialog",modelValue:_(p),"onUpdate:modelValue":t[9]||(t[9]=l=>ge(p)?p.value=l:p=l),transition:"scale-transition",persistent:""},{default:a(()=>[e(b,{class:"disconnected-card"},{default:a(()=>[e(Y,{color:"red"},{default:a(()=>[h("Oh no! Someone disconnected!")]),_:1}),e(v,null,{default:a(()=>[h(" Don't worry, you won't be penalized for this and will still receive your coins. Maybe the other person just had a bad internet connection... ")]),_:1}),e(z,{onClick:t[8]||(t[8]=l=>E())},{default:a(()=>[h("OK")]),_:1})]),_:1})]),_:1},8,["modelValue"]),e(k,{class:"kicked-dialog",modelValue:g.value,"onUpdate:modelValue":t[10]||(t[10]=l=>g.value=l),persistent:""},{default:a(()=>[e(b,{id:"kicked-card"},{default:a(()=>[e(v,null,{default:a(()=>[h(" You are getting kicked for bad behavior. ")]),_:1})]),_:1})]),_:1},8,["modelValue"]),e(ve,{onSend:M})])]),_:1})}}});export{Ie as default};
