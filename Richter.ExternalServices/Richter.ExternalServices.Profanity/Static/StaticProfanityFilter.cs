﻿/*WARNING, THERE'S SOME OFFENSIVE LANGUAGE IN THIS FILE!*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */

using System;
using System.Linq;
using Richter.ExternalServices.Profanity.Interfaces;

namespace Richter.ExternalServices.Profanity.Static
{
    class StaticProfanityFilter : IProfanityFilter
    {
        public ProfanityFilterResponse ContainsProfanity(ProfanityFilterRequest request)
        {
            var response = new ProfanityFilterResponse {ContainsProfanity = false, Created = DateTime.Now};
            var badwords = new[]
                               {
                                   "ass", "ass lick", "asses", "asshole", "assholes", "asskisser", "asswipe", "balls",
                                   "bastard", "beastial", "beastiality", "beastility", "beaver", "belly whacker",
                                   "bestial", "bestiality", "bitch", "bitcher", "bitchers", "bitches", "bitchin",
                                   "bitching", "blow job", "blowjob", "blowjobs", "bonehead", "boner", "brown eye",
                                   "browneye", "browntown", "bucket cunt", "bull shit", "bullshit", "bum", "bung hole",
                                   "butch", "butt", "butt breath", "butt fucker", "butt hair", "buttface", "buttfuck",
                                   "buttfucker", "butthead", "butthole", "buttpicker", "chink", "circle jerk", "clam",
                                   "clit", "cobia", "cock", "cocks", "cocksuck", "cocksucked", "cocksucker",
                                   "cocksucking", "cocksucks", "cooter", "crap", "cum", "cummer", "cumming", "cums",
                                   "cumshot", "cunilingus", "cunillingus", "cunnilingus", "cunt", "cuntlick",
                                   "cuntlicker", "cuntlicking", "cunts", "cyberfuc", "cyberfuck", "cyberfucked",
                                   "cyberfucker", "cyberfuckers", "cyberfucking", "damn", "dick", "dike", "dildo",
                                   "dildos", "dink", "dinks", "dipshit", "dong", "douche bag", "dumbass", "dyke",
                                   "ejaculate", "ejaculated", "ejaculates", "ejaculating", "ejaculatings", "ejaculation"
                                   , "fag", "fagget", "fagging", "faggit", "faggot", "faggs", "fagot", "fagots", "fags",
                                   "fart", "farted", "farting", "fartings", "farts", "farty", "fatass", "fatso",
                                   "felatio", "fellatio", "fingerfuck", "fingerfucked", "fingerfucker", "fingerfuckers",
                                   "fingerfucking", "fingerfucks", "fistfuck", "fistfucked", "fistfucker", "fistfuckers"
                                   , "fistfucking", "fistfuckings", "fistfucks", "fuck", "fucked", "fucker", "fuckers",
                                   "fuckin", "fucking", "fuckings", "fuckme", "fucks", "fuk", "fuks", "furburger",
                                   "gangbang", "gangbanged", "gangbangs", "gaysex", "gazongers", "goddamn", "gonads",
                                   "gook", "guinne", "hard on", "hardcoresex", "homo", "hooker", "horniest", "horny",
                                   "hotsex", "hussy", "jack off", "jackass", "jacking off", "jackoff", "jack-off", "jap"
                                   , "jerk", "jerk-off", "jism", "jiz", "jizm", "jizz", "kike", "kock", "kondum",
                                   "kondums", "kraut", "kum", "kummer", "kumming", "kums", "kunilingus", "lesbian",
                                   "lesbo", "merde", "mick", "mothafuck", "mothafucka", "mothafuckas", "mothafuckaz",
                                   "mothafucked", "mothafucker", "mothafuckers", "mothafuckin", "mothafucking",
                                   "mothafuckings", "mothafucks", "motherfuck", "motherfucked", "motherfucker",
                                   "motherfuckers", "motherfuckin", "motherfucking", "motherfuckings", "motherfucks",
                                   "muff", "nigger", "niggers", "orgasim", "orgasims", "orgasm", "orgasms", "pecker",
                                   "penis", "phonesex", "phuk", "phuked", "phuking", "phukked", "phukking", "phuks",
                                   "phuq", "pimp", "piss", "pissed", "pissrr", "pissers", "pisses", "pissin", "pissing",
                                   "pissoff", "prick", "pricks", "pussies", "pussy", "pussys", "queer", "retard",
                                   "schlong", "screw", "sheister", "shit", "shited", "shitfull", "shiting", "shitings",
                                   "shits", "shitted", "shitter", "shitters", "shitting", "shittings", "shitty", "slag",
                                   "sleaze", "slut", "sluts", "smut", "snatch", "spunk", "twat", "wetback", "whore",
                                   "wop"
                               };
            if (request.Text.Split(' ').Intersect(badwords).Count() > 0) response.ContainsProfanity = true;
            return response;
        }
    }
}