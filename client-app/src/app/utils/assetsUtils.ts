const getLiquidAccountIcon = (bankCode: string | null) =>
    `./assets/bankImages/${bankCode ?? "cash"}.jpg`;

const utils = {
    getLiquidAccountIcon,
}

export default utils;