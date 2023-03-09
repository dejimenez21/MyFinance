import { createBrowserRouter, RouteObject } from "react-router-dom";
import ExpensesDashboard from "../../features/expenses/ExpensesDashboard";
import App from "../layout/App";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            { path: '/', element: <ExpensesDashboard />},
            { path: '/expenses', element: <ExpensesDashboard />},
            // { path: '/liquidity', element: <}
        ]
    }
]

export const router = createBrowserRouter(routes);