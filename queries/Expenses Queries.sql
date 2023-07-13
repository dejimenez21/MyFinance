
select * from "EXPN"."Expenses"
where "Expenses"."Currency" = 'DOP'


select * from "EXPN"."Expenses"
where "Expenses"."Currency" = 'USD'

SELECT 
    E."Category", 
    SUM(CASE WHEN E."Currency" = 'DOP' THEN E."Amount" ELSE 0 END) AS DOP, 
    SUM(CASE WHEN E."Currency" = 'USD' THEN E."Amount" ELSE 0 END) AS USD
FROM 
    "EXPN"."Expenses" as E
GROUP BY 
    E."Category"

select * from "EXPN"."Expenses" as E
where E."Description" like '%Jennifer%'

select * from "EXPN"."Expenses" as E
where E."Category" = 'DiningOut'

select * from "EXPN"."Expenses" as E
where E."Category" = 'HobbiesAndLeisure'

