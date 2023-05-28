import { createTheme } from "@mui/material/styles";

export const GlobalStyles = createTheme({
    components: {
        MainSection: {
            flexGrow: 1, 
            width: 1000, 
            height: '100vh', 
            overflow: 'auto'
        }
    }
})