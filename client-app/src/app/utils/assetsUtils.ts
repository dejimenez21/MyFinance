const getLiquidAccountIcon = (bankCode: string | null) =>
  `./assets/bankImages/${bankCode ?? "cash"}.jpg`;

const getPaymentNetworkImage = (network: string) =>
  `./assets/paymentNetworkImages/${network}.jpg`;

const utils = {
  getLiquidAccountIcon,
  getPaymentNetworkImage,
};

export default utils;
