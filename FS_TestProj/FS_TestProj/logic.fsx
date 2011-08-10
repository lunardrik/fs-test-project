open System

module a =
    let (|Bool|Int|Float|String|) input = 
        // attempt to parse a bool 
        let success, res = Boolean.TryParse input 
        if success then Bool(res) 
        else  
            // attempt to parse an int 
            let success, res = Int32.TryParse input 
            if success then Int(res)
            else 
                // attempt to parse a float (Double) 
                let success, res = Double.TryParse input 
                if success then Float(res) 
                else String(input)